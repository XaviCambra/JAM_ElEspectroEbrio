using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIKey : MonoBehaviour
{
    public string m_Key = "";
    TMP_Text m_Text;

    public void SetText(string l_Text)
    {
        if (m_Text == null)
            m_Text = GetComponent<TMP_Text>();
        m_Text.text = l_Text;
    }
    public void EmptyText()
    {
        m_Text.text = "";
    }
}
