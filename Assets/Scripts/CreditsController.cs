using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] Animation m_CreditAnimation;
    [SerializeField] SceneLoader m_SceneLoader;

    float m_Timer = 0;

    // Update is called once per frame
    private void Start()
    {
        m_CreditAnimation.Play();
    }

    private void Update()
    {
        m_Timer += Time.deltaTime;
        if (m_Timer > m_CreditAnimation.clip.length)
            m_SceneLoader.UnloadSceneByName("Menu_Credits");
    }
}
