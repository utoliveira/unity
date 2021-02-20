using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    public Transform camera;

    // Update is called once per frame
    /*Called after everything on the update method is done*/
    void LateUpdate()
    {
        transform.LookAt(transform.position + camera.forward);
    }
}
