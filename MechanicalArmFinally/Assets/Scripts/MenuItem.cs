using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuItem : MonoBehaviour
{
    public Image image;
    public Text text;

    float waitTime = 1f;

    string loadSceneName;

    public void Setup(string _loadSceneName)
    {
        //设置图片
        ScenesPart scenesPart = AllScenes.instance.GetSceneMassage(_loadSceneName);
        image.sprite = scenesPart.sceneSprite;
        text.text = scenesPart.name;

        loadSceneName = scenesPart.sceneName;
    }

    public void LoadScene()
    {
        //摄像机和场景变化
        //StartCoroutine(WaitLoad());
        SceneManager.LoadScene(loadSceneName);
    }

    //IEnumerator WaitLoad()
    //{
    //    yield return new WaitForSeconds(waitTime);
    //    SceneManager.LoadScene(loadSceneName);
    //}
}
