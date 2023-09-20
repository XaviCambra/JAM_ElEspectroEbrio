using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float TimeCountdown;
    private float CurrentTime;
    private TextMeshProUGUI TextMeshPro;

    [SerializeField] SceneLoader m_SceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        TextMeshPro = GetComponent<TextMeshProUGUI>();
        CurrentTime = TimeCountdown;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime >= 0)
        {
            CurrentTime -= Time.deltaTime;
            TextMeshPro.text = CurrentTime.ToString("0");
        }
        else
        {
            m_SceneLoader.LoadSceneByName("Game Over");
        }
    }
}
