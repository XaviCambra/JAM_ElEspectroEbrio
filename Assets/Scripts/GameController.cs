using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController m_Instance;

    [SerializeField] private LanguageSO m_Language;
    [SerializeField] List<LanguageSO> m_LanguagesList = new List<LanguageSO>();
    

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            Destroy(gameObject);
        else
            m_Instance = this;
            DontDestroyOnLoad(gameObject);
    }

    public LanguageSO GetLanguage()
    {
        return m_Language;
    }
    public void SetLanguage(LanguageSO l_Language)
    {
        m_Language = l_Language;
    }

    public List<LanguageSO> GetLanguagesList()
    {
        return m_LanguagesList;
    }
}
