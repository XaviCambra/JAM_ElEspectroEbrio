using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public CustomerManager customerManager;
    public Sprite successSprite;
    public Sprite failSprite;

    private int orderNumber = 1;

    public void TaskOnClick()
    {
        bool orderCorrect = customerManager.ProcessOrder();
        if (orderCorrect)
        {
            Debug.Log("Order correct! :D");
            GameObject.Find("Order" + orderNumber.ToString()).GetComponent<UnityEngine.UI.Image>().sprite = successSprite;
        }            
        else
        {
            Debug.Log("Order not correct! D:");
            var currentOrderMark = GameObject.Find("Order" + orderNumber.ToString());
            currentOrderMark.GetComponent<UnityEngine.UI.Image>().sprite = failSprite;
        }
        orderNumber++;
    }
}
