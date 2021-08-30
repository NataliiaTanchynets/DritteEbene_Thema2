using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderScript : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 2f;

    // Update is called once per frame
    public void LoadNextLevel ()
    {
        Debug.Log("Wir sind in SceneLoadScript");
        StartCoroutine(LoadLevel());
        
    }
    IEnumerator LoadLevel ()
    {

        Debug.Log("Wir sind in IEnumerator");
        transition.SetTrigger("Ende");
        yield return new WaitForSeconds(transitionTime);
       
        SceneManager.LoadScene(2);

    }
}
