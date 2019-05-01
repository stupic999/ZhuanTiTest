using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingBar: MonoBehaviour
{
    public Text loadingText;
    public Slider sliderBar;

    void Start()
    {
        sliderBar.gameObject.SetActive(false);
        GameController.isLoadingScene = true;
    }

    void Update()
    {
        if (GameController.isLoadingScene)
        {
            GameController.isLoadingScene = false;

            sliderBar.gameObject.SetActive(true);

            loadingText.text = "Loading...";

            StartCoroutine(LoadNewScene(GameController.LoadingSceneName));
        }
    }

    IEnumerator LoadNewScene(string sceneName)
    {
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);
            sliderBar.value = progress;
            loadingText.text = progress * 100f + "%";
            yield return null;
        }
    }
}