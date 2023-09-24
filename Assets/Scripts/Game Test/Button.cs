using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public CustomerManager customerManager;
    UnityEngine.UI.Button btn;
    void Start()
    {
        btn = GetComponent<UnityEngine.UI.Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        bool orderCorrect = customerManager.ProcessOrder();
        if (orderCorrect)
            Debug.Log("Order correct! :D");
        else
            Debug.Log("Order not correct! D:");
    }
}
