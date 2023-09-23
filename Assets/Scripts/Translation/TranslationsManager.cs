using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslationsManager : MonoBehaviour
{
    [SerializeField]
    private List<UIKey> texts;
    GameController gameController;

    private void Start()
    {
        TranslateTexts();
    }

    public void TranslateTexts()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        string lang = GetCurrentLanguage().ToUpper();
        Translations trans = Translations.LoadTranslationsFromFile("Assets\\Resources\\Localization\\Translations.json");
        var translations = trans.TextsByLang[lang];
        foreach (UIKey text in texts)
        {
            try
            {
                text.SetText(translations[text.m_Key]);
            }catch(System.Exception e) { text.SetText("ERROR - NULL KEY"); }
                
        }
    }

    private string GetCurrentLanguage()
    {
        return gameController.GetLanguage().m_LanguageName;
    }

    public void SetCurrentLanguage(LanguageSO l_Language)
    {
        gameController.SetLanguage(l_Language);
        TranslateTexts();
    }

    public List<LanguageSO> GetLanguagesList()
    {
        return gameController.GetLanguagesList();
    }
}
