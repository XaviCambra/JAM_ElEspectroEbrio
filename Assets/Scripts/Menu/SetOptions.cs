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
    }

    public void SetFullscreen(bool l_Fullscreen)
    {
        m_Fullscreen = l_Fullscreen;
    }

    public void ApplyResolution()
    {
        Screen.SetResolution(m_Resolution.width, m_Resolution.height, m_Fullscreen);
    }
}
