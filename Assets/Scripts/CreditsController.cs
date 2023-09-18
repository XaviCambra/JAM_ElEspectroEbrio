using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] MoveToPoint m_MoveImage;
    [SerializeField] SceneLoader m_SceneLoader;

    // Update is called once per frame
    void Update()
    {
        m_MoveImage.TransformToPoint();
        if (m_MoveImage.IsOnPoint())
            m_SceneLoader.UnloadSceneByName("Menu_Creditos");
    }
}
