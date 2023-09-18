using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string l_SceneName)
    {
        SceneManager.LoadScene(l_SceneName);
    }

    public void LoadSceneAsyncByName(string l_SceneName)
    {
        StartCoroutine(LoadSceneAsync(l_SceneName));
    }

    public void LoadSceneAsyncAdditiveByName(string l_SceneName)
    {
        StartCoroutine(LoadSceneAsyncAdditive(l_SceneName));
    }

    public void UnloadSceneByName(string l_SceneName)
    {
        StartCoroutine(UnloadSceneAsync(l_SceneName));
    }

    IEnumerator LoadSceneAsync(string l_SceneName)
    {
        AsyncOperation l_AsyncLoad = SceneManager.LoadSceneAsync(l_SceneName);

        while (!l_AsyncLoad.isDone)
        {
            yield return null;
        }
    }

    IEnumerator LoadSceneAsyncAdditive(string l_SceneName)
    {
        /*AsyncOperation l_AsyncLoad = */SceneManager.LoadSceneAsync(l_SceneName, LoadSceneMode.Additive);
        yield return null;
        //while (!l_AsyncLoad.isDone)
        //{
        //    yield return null;
        //}
    }

    IEnumerator UnloadSceneAsync(string l_SceneName)
    {
        AsyncOperation l_AsyncLoad = SceneManager.UnloadSceneAsync(l_SceneName);

        while (!l_AsyncLoad.isDone)
        {
            yield return null;
        }
    }
}
