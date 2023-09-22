using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslationsManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> texts;
    GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>().GetComponent<GameController>();
        string lang = GetCurrentLanguage();
        Translations trans = Translations.LoadTranslationsFromFile("Assets\\Resources\\Localization\\Translations.json");
        var translations = trans.TextsByLang[lang];
        foreach (TextMeshProUGUI text in texts)
        {
            text.text = translations[text.text];
        }
    }

    private string GetCurrentLanguage()
    {
        return gameController.GetLanguage().m_Name;
    }

    public void SetCurrentLanguage(LanguageSO l_Language)
    {
        gameController.SetLanguage(l_Language);
    }
}
