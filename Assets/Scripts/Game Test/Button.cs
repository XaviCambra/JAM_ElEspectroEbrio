using FMODUnity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public CustomerManager customerManager;
    public Sprite successSprite;
    public Sprite failSprite;
    public AudioManager audioManager;
    [field: SerializeField] public EventReference failSound { get; private set; }
    [field: SerializeField] public EventReference successSound { get; private set; }
    [field: SerializeField] public EventReference mainSong { get; private set; }
    [SerializeField]private int ordersInLevel;

    private int orderNumber = 1;
    private int correctOrders = 0, inCorrectOrders = 0;

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
            correctOrders++;
        }            
        else
        {
            Debug.Log("Order not correct! D:");
            var currentOrderMark = GameObject.Find("Order" + orderNumber.ToString());
            currentOrderMark.GetComponent<UnityEngine.UI.Image>().sprite = failSprite;
            audioManager.PlayOneShot(failSound);
            inCorrectOrders++;
        }
        orderNumber++;
        if(orderNumber == ordersInLevel + 1) 
        {
            if (correctOrders >= (ordersInLevel / 2))
                SceneManager.LoadScene("Menu_Credits");
            else
                SceneManager.LoadScene("Menu_GameOver");
        }
    }
}
