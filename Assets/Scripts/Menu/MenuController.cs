using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] SceneLoader m_SceneLoader;

    [SerializeField] string m_SceneName;

    [SerializeField] Animation m_Animation;

    [Tooltip("Animación de entrada"), SerializeField] protected AnimationClip m_IntroAnimationClip;
    [Tooltip("Animación de salida"), SerializeField] protected AnimationClip m_OutroAnimationClip;

    [SerializeField] bool m_AutomaticUnload;

    protected void Start()
    {
        m_IntroAnimationClip.legacy = true;
        if (m_OutroAnimationClip != null)
            m_OutroAnimationClip.legacy = true;

        m_Animation.clip = m_IntroAnimationClip;
        m_Animation.Play();
        if(m_AutomaticUnload)
            StartCoroutine(UnloadSceneByTime());
    }

    public void UnloadScene()
    {
        m_Animation.clip = m_OutroAnimationClip;
        m_Animation.Play();
        StartCoroutine(UnloadSceneByTime());
    }

    IEnumerator UnloadSceneByTime()
    {
        float timer;

        if (m_AutomaticUnload)
            timer = m_IntroAnimationClip.length;
        else
            timer = m_OutroAnimationClip.length;

        while (timer > 0)
        {
            timer -= Time.deltaTime;
            yield return null;
        }

        m_SceneLoader.UnloadSceneByName(m_SceneName);
    }
}
