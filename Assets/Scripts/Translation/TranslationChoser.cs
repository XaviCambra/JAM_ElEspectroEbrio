using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TranslationChoser : MonoBehaviour
{
    [SerializeField] TMP_Dropdown m_Dropdown;
    [SerializeField] TranslationsManager[] m_Translator;

    private void Start()
    {
        m_Translator = FindObjectsOfType<TranslationsManager>();
        if (m_Translator == null)
            return;
        List< LanguageSO> l_LanguagesList = m_Translator[0].GetLanguagesList();
        foreach (LanguageSO language in l_LanguagesList)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = language.m_LanguageName;
            option.image = language.m_Sprite;
            m_Dropdown.options.Add(option);
        }
    }

    public void ChangeLanguage(TMP_Dropdown l_Dropdown)
    {
        foreach(TranslationsManager l_Translator in m_Translator)
        {
            l_Translator.SetCurrentLanguage(l_Translator.GetLanguagesList()[l_Dropdown.value]);
        }
    }
}
