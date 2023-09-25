using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public class Translations
{
    public Dictionary<string, Dictionary<string, string>> TextsByLang;
    public static Translations LoadTranslationsFromFile(string filename)
    {
        using (StreamReader r = new StreamReader(filename))
        {
            string json = r.ReadToEnd();
            Translations trs = JsonConvert.DeserializeObject<Translations>(json);
            return trs;
        }
    }
    public static Translations LoadTranslationsFromResources()
    {
        var trsText = Resources.Load<TextAsset>("Localization/Translations");
        Translations trs = JsonConvert.DeserializeObject<Translations>(trsText.text);
        return trs;
    }
}