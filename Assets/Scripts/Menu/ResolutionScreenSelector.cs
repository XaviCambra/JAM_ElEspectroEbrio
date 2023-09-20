using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResolutionScreenSelector : MonoBehaviour
{
    [SerializeField] TMP_Dropdown m_Dropdown;

    Resolution[] m_Resolution;

    [SerializeField] SetOptions m_SetOptions;

    private void Start()
    {
        m_Resolution = Screen.resolutions;
        for(int i = 0;  i < m_Resolution.Length; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = m_Resolution[i].ToString();
            m_Dropdown.options.Add(option);

            if (m_Resolution[i].Equals(Screen.currentResolution))
            {
                m_Dropdown.value = i;
            }
        }

        m_Dropdown.onValueChanged.AddListener(delegate
        {
            SetResolutionById(m_Dropdown);
        });
    }

    public void SetResolutionById(TMP_Dropdown l_Dropdown)
    {
        m_SetOptions.SetResolution(m_Resolution[l_Dropdown.value]);
    }
}
