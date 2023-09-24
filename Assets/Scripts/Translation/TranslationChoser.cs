using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static Unity.VisualScripting.Icons;

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
        for(int i = 0;  i < l_LanguagesList.Count; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
            option.text = l_LanguagesList[i].m_LanguageName;
            option.image = l_LanguagesList[i].m_Sprite;
            m_Dropdown.options.Add(option);
        }
        for (int i = 0; i < l_LanguagesList.Count; i++)
        {
            
            if (l_LanguagesList[i].m_LanguageName == m_Translator[0].GetCurrentLanguage())
            {
                m_Dropdown.value = i;
            }
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
