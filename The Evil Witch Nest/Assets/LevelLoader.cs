using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
 
    public void loadNextLevel()
    {
        StartCoroutine(LoadLevel(1, 1f));
    }


    IEnumerator LoadLevel(int levelIndex, float transitionTime)
    {
        animator.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }

}