using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreButton : MonoBehaviour
{
    public void TaskOnClick()
    {
        SceneManager.LoadScene(ScoreManager.NextScene);
    }
}
