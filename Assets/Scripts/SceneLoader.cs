using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneByName(string l_SceneName)
    {
        SceneManager.LoadScene(l_SceneName);
    }

    public void LoadSceneByIndex(int l_SceneIndex)
    {
        SceneManager.LoadScene(l_SceneIndex);
    }

    public void LoadSceneAsyncByName(string l_SceneName)
    {
        StartCoroutine(SceneAsync(SceneManager.GetSceneByName(l_SceneName).buildIndex));
    }

    IEnumerator SceneAsync(int l_SceneIndex)
    {
        AsyncOperation l_AsyncLoad = SceneManager.LoadSceneAsync(l_SceneIndex);

        while (!l_AsyncLoad.isDone)
        {
            yield return null;
        }
    }
}
