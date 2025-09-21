using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehaviour :  MonoBehaviour{}
    public enum Scene
    {
        LoadingScene,
        GameScene
    }

    private static Action _onLoaderCallback;
    private static AsyncOperation _loadingAsyncOperation;
    public static void Load(Scene scene)
    {
        SceneManager.LoadScene(Scene.LoadingScene.ToString());
        
        _onLoaderCallback = () =>
        {
            GameObject loadingObject = new GameObject("Loading GameObject");
            loadingObject.AddComponent<LoadingMonoBehaviour>().StartCoroutine(LoadSceneAsync(scene));
        };
    }

    public static float GetLoadingProgress()
    {
        if (_loadingAsyncOperation != null)
        {
            return _loadingAsyncOperation.progress;
        }

        return 1;
    }
    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        
        _loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());


        while (!_loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }
    
    public static void LoaderCallback()
    {
        if (_onLoaderCallback != null)
        {
            _onLoaderCallback();
            _onLoaderCallback = null;
        }
    }
}