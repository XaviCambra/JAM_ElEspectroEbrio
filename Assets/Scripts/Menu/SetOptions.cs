using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOptions : MonoBehaviour
{
    [SerializeField] Resolution m_Resolution;
    [SerializeField] bool m_Fullscreen;

    public void SetResolution(Resolution l_Resolution)
    {
        m_Resolution = l_Resolution;
        Debug.Log("Resolution: " + m_Resolution.width + " x " +  m_Resolution.height);
    }

    public void SetFullscreen(bool l_Fullscreen)
    {
        m_Fullscreen = l_Fullscreen;
        Debug.Log(m_Resolution.width + " x " + m_Resolution.height);
        Debug.Log("Fullscreen: " + m_Fullscreen);
    }

    public void ApplyResolution()
    {
        Screen.SetResolution(m_Resolution.width, m_Resolution.height, m_Fullscreen);
    }
}
