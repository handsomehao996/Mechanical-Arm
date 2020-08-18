using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllScenes : MonoBehaviour
{
    public ScenesPart[] scenesParts;

    public static AllScenes instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }

    public ScenesPart[] GetAllScenesMassage()
    {
        return scenesParts;
    }

    public ScenesPart GetSceneMassage(string _name)
    {
        ScenesPart scenes = null;
        foreach (var item in scenesParts)
        {
            if (item.sceneName.Equals(_name))
            {
                scenes = item;
                break;
            }
        }
        return scenes;
    }
}

[System.Serializable]
public class ScenesPart
{
    public string sceneName;
    public string name;
    public Sprite sceneSprite;
}