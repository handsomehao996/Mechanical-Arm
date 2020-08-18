using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitClick : MonoBehaviour
{
    public float waitTime = 0.5f;

    public void LoadScene(string _sceneName)
    {
        //StartCoroutine(WaitLoad(_sceneName));
        SceneManager.LoadScene(_sceneName);
    }

    //IEnumerator WaitLoad(string _sceneName)
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    SceneManager.LoadScene(_sceneName);
    //}

    public void ExitGame()
    {
        Application.Quit();
    }
}
