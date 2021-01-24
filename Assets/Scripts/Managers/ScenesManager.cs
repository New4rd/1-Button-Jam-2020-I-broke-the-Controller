using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    static public ScenesManager Instance;

    public bool sceneOperationDone;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        StartCoroutine(LoadScene("Main Title Scene"));
        StartCoroutine(LoadScene("Black Fade Scene"));
    }


    public IEnumerator LoadScene(string sceneName, bool setActive = false)
    {
        sceneOperationDone = false;
        AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        yield return new WaitUntil(() => async.isDone);
        if (setActive) SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
        sceneOperationDone = true;
    }


    public IEnumerator UnloadSceneByObject (GameObject obj)
    {
        sceneOperationDone = false;
        Debug.Log("Unloading scene named::: " + obj.scene.name);
        AsyncOperation async = SceneManager.UnloadSceneAsync(obj.scene, UnloadSceneOptions.None);
        yield return new WaitUntil(() => async.isDone);
        sceneOperationDone = true;
    }


    public IEnumerator UnloadScene (string sceneName)
    {
        sceneOperationDone = false;
        AsyncOperation async = SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.None);
        yield return new WaitUntil(() => async.isDone);
        sceneOperationDone = true;
    }


    public IEnumerator ReloadScene (string sceneName)
    {
        ScreenFadeHandler.Instance.ScreenFadeOut();

        StartCoroutine(UnloadScene(sceneName));
        //yield return new WaitUntil(() => sceneOperationDone);
        Debug.Log("SCENE UNLOADED FOR RELOAD");
        StartCoroutine(LoadScene(sceneName));

        ScreenFadeHandler.Instance.ScreenFadeIn();
        yield break;
    }


    public bool IsSceneLoaded (string sceneName)
    {
        return SceneManager.GetSceneByName(sceneName).isLoaded;
    }
}
