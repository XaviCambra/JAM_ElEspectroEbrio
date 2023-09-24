using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public CustomerManager customerManager;

    public void TaskOnClick()
    {
        bool orderCorrect = customerManager.ProcessOrder();
        if (orderCorrect)
            Debug.Log("Order correct! :D");
        else
            Debug.Log("Order not correct! D:");
    }
}
