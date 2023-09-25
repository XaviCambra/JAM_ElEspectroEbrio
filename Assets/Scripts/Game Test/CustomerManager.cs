using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
public class CustomerManager : MonoBehaviour
{
    public GlassManager gm;
    public UnityEngine.UI.Image customer1;
    public UnityEngine.UI.Image customer2;

    [SerializeField] Transform topX;
    [SerializeField] Transform topX2;
    [SerializeField] float m_Speed;
    [SerializeField] UIKey customerDialogue;  // preguntar por qu� esto era antes un UIKey
    [SerializeField] TranslationsManager translationManager;
    private bool customerEntranceFinished = true;
    private bool exitCustomer = false;
    [SerializeField] List<Client> customerList = new List<Client>();
    private int customerIndex;
    private UnityEngine.UI.Image customerEntering;
    private UnityEngine.UI.Image customerLeaving;
    private Vector3 customerInitPosition;
    public int Level;
    private void Start()
    {
        customerList = fetchClientList();
        customerEntering = customer1;
        customerInitPosition = customer1.transform.position;

        Sprite sprite = customerList[customerIndex].Sprite;
        customer1.sprite = sprite;
        customerEntranceFinished = false;
    }
    void FixedUpdate()
    {

        if (!customerEntranceFinished)
        {
            if (customerEntering.transform.position.x <= topX.transform.position.x)
                customerEntering.transform.position += Vector3.right * m_Speed;
            else
            {
                //TODO: el texto debe ser cargado desde un json y debe poderse pasar a otros di�logos
                customerDialogue.m_Key = customerList[customerIndex].WantedDrink.TextDescriptionKey.Trim();
                translationManager.TranslateTexts();
                customerEntranceFinished = true;
                //customerIndex++;
            }
        }
        if (customerLeaving != null)
        {
            if (exitCustomer && customerLeaving.transform.position.x <= topX2.transform.position.x)
            {
                customerLeaving.transform.position += Vector3.right * m_Speed;
            }
            else
            {
                if (customerLeaving.transform.position.x >= topX2.transform.position.x)
                {
                    exitCustomer = false;
                    customerLeaving.transform.position = customerInitPosition;
                }

            }
        }
    }
    private List<Client> fetchClientList()
    {
        //TODO: usar las siguient lineas
        //ClientsInLevel cil = ClientsInLevel.LoadClientsFromFile("Assets\\Resources\\ClientsInLevels.json");
        //return cil.Clients;
        if(Level == 1)
        {
            return new List<Client>() { //TODO: comentar esto
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 1"),
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 2"),
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 3"),
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 4"),
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 5"),
                Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 6")
            };
        }
        if(Level == 2)
        {
            return new List<Client>() { //TODO: comentar esto
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 1"),
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 2"),
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 3"),
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 4"),
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 5"),
                Resources.Load<Client>("ScriptableObjects/Clients/Segundo Nivel/Peticion 6")
            };
        }
        return new List<Client>() { }; 
    }

    public bool ProcessOrder()
    {
        exitCustomer = true;
        customerDialogue.EmptyText();     
        customerIndex++;
        customerEntranceFinished = false;
        if (customerIndex % 2 == 0)
        {
            customerEntering = customer1;
            customerLeaving = customer2;
         }
        else
        {
            customerEntering = customer2;
            customerLeaving = customer1;
        }
        if(customerIndex < customerList.Count)
        {
            Sprite sprite = customerList[customerIndex].Sprite;
            customerEntering.sprite = sprite;
        }        
        List<Ingredient> actualDrinkIngredients = gm.GetIngredients();
        Drink actualDrink = gm.GetDrink();
        var customer = customerList[customerIndex-1];
        //checkear por si hay alg�n ingrediente no deseado en la bebida
        foreach (Ingredient notWantedIng in customer.WantedDrink.UndesiredIngredients)
        {
            foreach (Ingredient i in actualDrinkIngredients)
            {
                if (i.IngredientName == notWantedIng.IngredientName)
                    return false;
            }
        }
        //checkear si hay alguna propiedad no deseada en la bebida
        foreach (Ingredient.IngredientProperties ip in customer.WantedDrink.UndesiredProperties)
        {
            foreach (Ingredient i in actualDrinkIngredients)
            {
                foreach (Ingredient.IngredientProperties actualip in i.m_Properties)
                {
                    if (actualip == ip)
                    {
                        Debug.Log("propiedad no deseado: " + actualip);
                        return false;
                    }
                }
            }
        }
        if (customer.WantedDrink.Temperature != Ingredient.IngredientTemperature.Indiferente)
        {
            if (customer.WantedDrink.Temperature != actualDrink.Temperature)
            {
                Debug.Log("temperatura no deseado: " + actualDrink.Temperature);
                return false;
            }
        }
        //checkear si todos los ingredientes deseados est�n
        int desiredIngredientsCount = 0;
        foreach (Ingredient i in customer.WantedDrink.Ingredients)
        {
            foreach (Ingredient actualIngredient in actualDrinkIngredients)
            {
                if (i.IngredientName == actualIngredient.IngredientName)
                    desiredIngredientsCount++;
            }
        }
        if (desiredIngredientsCount < customer.WantedDrink.Ingredients.Count)
            return false;

        //checkear si todas las propiedades deseadas est�n
        int desiredPropertiesCount = 0;
        foreach (Ingredient.IngredientProperties ip in customer.WantedDrink.Properties)
        {
            foreach (Ingredient i in actualDrinkIngredients)
            {
                foreach (Ingredient.IngredientProperties actualip in i.m_Properties)
                {
                    if (actualip == ip)
                        desiredPropertiesCount++;
                }
            }
        }
        if (desiredPropertiesCount < customer.WantedDrink.Properties.Count)
        {
            Debug.Log("Count is false");
            return false;
        }
        if(customer.WantedDrink.GlassTypesAccepted.Count > 0)
        {
            if (!customer.WantedDrink.GlassTypesAccepted.Contains(actualDrink.GlassType))
            {
                Debug.Log("Glass not accepted");
                return false;
            }
        }
        gm.Clear();
        return true;
    }
}