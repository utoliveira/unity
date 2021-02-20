using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyAI : MonoBehaviour
{
    private Seeker seeker;
    private Rigidbody2D rigidBody;

    public Transform target;
    public float speed = 200;

    /*How close the gameobject needs to be close to a waypoint
     * until it can moves to the next on*/
    public float nextWaypointDistance = 3f;

    /*Path containing all the waypoints until the target*/
    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEndOfPath = false;

    public Transform gfx;

    private void Start()
    {
        seeker = this.GetComponent<Seeker>();
        rigidBody = this.GetComponent<Rigidbody2D>();

        /*This function will be called instantly and update every .5 seconds*/
        InvokeRepeating("UpdatePath", 0f, .5f);
        
    }

    private void UpdatePath()
    {
        /*It will only be updated when the calculation is done*/
        if(seeker.IsDone())
            seeker.StartPath(rigidBody.position, target.position, OnPathComplete);
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (path == null) return;

        if(currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }

        reachedEndOfPath = false;

        /*It will generate a vector pointing to the position of the place that it will be and normalize it
         to be in a magnitude of 1*/
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rigidBody.position).normalized;
        Vector2 force = direction * speed * Time.fixedDeltaTime;

        /*Dont forget to apply Linear Drag so the rigid body can stop*/
        rigidBody.AddForce(force);

        float distance = Vector2.Distance(rigidBody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
            currentWaypoint++;

        if (force.x >= 0.01f)
            gfx.localScale = new Vector3(12f, 12f, 1f);

        else if (force.x <= -0.01f)
            gfx.localScale = new Vector3(-12f, 12f, 1f);

    }

    

    void OnPathComplete(Path generatedPath)
    {
        if (!generatedPath.error)
        {
            this.path = generatedPath;
            currentWaypoint = 0;
        }
    }
}
