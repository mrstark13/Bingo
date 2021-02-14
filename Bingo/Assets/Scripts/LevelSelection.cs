using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public UnityEditor.SceneAsset scene;
    public Button LvlButt;
    void Start()
    {
        LvlButt.onClick.AddListener(SceneLoad);
    }

    void SceneLoad()
    {
        SceneManager.LoadScene(scene.name);
    }
    void OnDisable()
    {
        LvlButt.onClick.RemoveAllListeners();
    }
}
