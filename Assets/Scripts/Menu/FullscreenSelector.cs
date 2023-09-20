using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FullscreenSelector : MonoBehaviour
{
    [SerializeField] SetOptions m_SetOptions;

    [SerializeField] Toggle m_Toggle;

    private void Start()
    {
        m_Toggle.isOn = Screen.fullScreen;

        m_Toggle.onValueChanged.AddListener(delegate
        {
            SetFullscreen(m_Toggle);
        });
    }

    public void SetFullscreen(Toggle l_Toggle)
    {
        m_SetOptions.SetFullscreen(l_Toggle);
    }
}
