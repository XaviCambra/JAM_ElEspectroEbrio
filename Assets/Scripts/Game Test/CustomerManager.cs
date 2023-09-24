using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]  Transform topX;
    [SerializeField] float m_Speed;
    [SerializeField] UIKey customerDialogue;
    [SerializeField] TranslationsManager translationManager;
    private bool customerEntranceFinished = true;
    [SerializeField] List<Client> customerList = new List<Client>();
    private int customerIndex;
    int drinkOfCostumerIndex;
    private void Start()
    {
        //List<Client> customerList = fetchClientList();
    }
    void FixedUpdate()
    {
        if (!customerEntranceFinished)
        {
            if (transform.position.x <= topX.transform.position.x)
                transform.position += Vector3.right * m_Speed;
            else
            {
                //TODO: el texto debe ser cargado desde un json y debe poderse pasar a otros diálogos
                drinkOfCostumerIndex = Random.Range(0, customerList[customerIndex].WantedDrinks.Count);
                customerDialogue.m_Key = customerList[customerIndex].WantedDrinks[drinkOfCostumerIndex].TextDescriptionKey;
                translationManager.TranslateTexts();
                customerEntranceFinished = true;
                customerIndex++;
            }
        }        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && customerEntranceFinished)
        {
            //GameObject go = new GameObject();
            //go.AddComponent<SpriteRenderer>();
            //Sprite sprite = customerList[customerIndex].Sprite;
            //go.GetComponent<SpriteRenderer>().sprite = sprite;
            customerEntranceFinished = false;
        }
    }

    //private List<Client> fetchClientList()
    //{
    //    //TODO: usar las siguient lineas
    //    //ClientsInLevel cil = ClientsInLevel.LoadClientsFromFile("Assets\\Resources\\ClientsInLevels.json");
    //    //return cil.Clients;
    //    return new List<Client>() { //TODO: comentar esto
    //        new Client{ 
    //            Name = "Vampiro",
    //            Sprite = "Sprites/Vampiro",
    //            WantedDrinks = new List<Drink>
    //            {

    //            }
    //        },
    //        new Client{ },
    //    }; 
    //}

    public bool ProcessOrder(Drink d)
    {
        var customer = customerList[customerIndex];
        foreach (var cond in customer.WantedDrinks)
        {
            if (cond.Want && cond.Drink != d)
                return false;
            if (!cond.Want && cond.Drink == d)
                return false;
        }
        int wantedIngredients = customer.WantedIngredients.Count;
        int gotWantedIngredients = 0;
        foreach (IngredientOrder io in customer.WantedIngredients)
        {
            foreach (Ingredient i in d.Ingredients)
            {
                if (io.Wanted && io.Ingredient == i)
                {
                    gotWantedIngredients++;
                }
                if (!io.Wanted && io.Ingredient == i)
                    return false;
            }
        }
        if (wantedIngredients < gotWantedIngredients)
            return false;
        return true;
    }
}
