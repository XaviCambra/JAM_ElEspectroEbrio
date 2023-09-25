using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button : MonoBehaviour
{
    public CustomerManager customerManager;
    public Sprite successSprite;
    public Sprite failSprite;
    public AudioManager audioManager;
    [field: SerializeField] public EventReference failSound { get; private set; }
    [field: SerializeField] public EventReference successSound { get; private set; }
    [field: SerializeField] public EventReference mainSong { get; private set; }

    private int orderNumber = 1;

    private void Start()
    {
        audioManager.PlayOneShot(mainSong);
    }

    public void TaskOnClick()
    {
        bool orderCorrect = customerManager.ProcessOrder();
        if (orderCorrect)
        {
            Debug.Log("Order correct! :D");
            GameObject.Find("Order" + orderNumber.ToString()).GetComponent<UnityEngine.UI.Image>().sprite = successSprite;
            audioManager.PlayOneShot(successSound);
        }            
        else
        {
            Debug.Log("Order not correct! D:");
            var currentOrderMark = GameObject.Find("Order" + orderNumber.ToString());
            currentOrderMark.GetComponent<UnityEngine.UI.Image>().sprite = failSprite;
            audioManager.PlayOneShot(failSound);
        }
        orderNumber++;
    }
}
