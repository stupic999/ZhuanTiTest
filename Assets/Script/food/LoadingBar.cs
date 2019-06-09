using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar: MonoBehaviour
{
    public Text loadingText;

    void Start()
    {
        loadingText.text = "Loading...";
        StartCoroutine(LoadNewScene("Hospital"));
    }

    void Update()
    {


    }

    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }
}