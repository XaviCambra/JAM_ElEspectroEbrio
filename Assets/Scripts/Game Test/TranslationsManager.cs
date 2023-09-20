using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TranslationsManager : MonoBehaviour
{
    [SerializeField]
    private List<TextMeshProUGUI> texts;
    void Start()
    {
        string lang = GetCurrentLanguage();
        Translations trans = Translations.LoadTranslationsFromFile("Translations.json");
        var translations = trans.TextsByLang[lang];
        foreach(TextMeshProUGUI text in texts)
        {
            text.text = translations[text.text];
        }
    }

    private string GetCurrentLanguage()
    {
        // TODO: implementar esto para que coja el idioma seleccionado en opciones
        return "ESP";
    }

}
