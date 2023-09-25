using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.VisualScripting.Icons;
using UnityEngine.UI;

public class TranslationChoser : MonoBehaviour
{
    [SerializeField] TranslationsManager m_TranslationsManager;
    [SerializeField] LanguageSO m_Language;
    [SerializeField] Image m_ImageBackground;
    [SerializeField] TranslationChoser[] m_TranslationChoser;

    private void Start()
    {
        BackgroundEnabler();
    }

    public void SetLanguage()
    {
        m_TranslationsManager.SetCurrentLanguage(m_Language);
        foreach(var t in m_TranslationChoser)
        {
            t.BackgroundEnabler();
        }
    }

    public void BackgroundEnabler()
    {
        m_ImageBackground.enabled = m_TranslationsManager.GetCurrentLanguage() == m_Language;
    }
}
