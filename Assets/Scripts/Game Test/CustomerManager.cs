using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerManager : MonoBehaviour
{
    public GlassManager gm;

    [SerializeField]  Transform topX;
    [SerializeField] float m_Speed;
    [SerializeField] TextMeshProUGUI customerDialogue;  // preguntar por qué esto era antes un UIKey
    [SerializeField] TranslationsManager translationManager;
    private bool customerEntranceFinished = true;
    [SerializeField] List<Client> customerList = new List<Client>();
    private int customerIndex;
    private void Start()
    {
        customerList = fetchClientList();
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
                customerDialogue.text = customerList[customerIndex].WantedDrink.TextDescriptionKey;
                translationManager.TranslateTexts();
                customerEntranceFinished = true;
                //customerIndex++;
            }
        }        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && customerEntranceFinished)
        {
            Sprite sprite = customerList[customerIndex].Sprite;
            gameObject.GetComponent<UnityEngine.UI.Image>().sprite = sprite;
            customerEntranceFinished = false;
        }
    }

    private List<Client> fetchClientList()
    {
        //TODO: usar las siguient lineas
        //ClientsInLevel cil = ClientsInLevel.LoadClientsFromFile("Assets\\Resources\\ClientsInLevels.json");
        //return cil.Clients;
        
        return new List<Client>() { //TODO: comentar esto
            Resources.Load<Client>("ScriptableObjects/Clients/Primer Nivel/Peticion 1")
        };
    }

    public bool ProcessOrder()
    {
        List<Ingredient> actualDrink = gm.GetIngredients();
        var customer = customerList[customerIndex];
        //checkear por si hay algún ingrediente no deseado en la bebida
        foreach (Ingredient notWantedIng in customer.WantedDrink.UndesiredIngredients)
        {
            foreach(Ingredient i in actualDrink)
            {
                if(i.name == notWantedIng.name)
                    return false;
            }
        }
        //checkear si hay alguna propiedad no deseada en la bebida
        foreach (Ingredient.IngredientProperties ip in customer.WantedDrink.UndesiredProperties)
        {
            foreach (Ingredient i in actualDrink)
            {
                foreach(Ingredient.IngredientProperties actualip in i.m_Properties)
                {
                    if (actualip == ip)
                        return false;
                }
            }
        }
        //TODO: check de temperatura

        //checkear si todos los ingredientes deseados están
        int desiredIngredientsCount = 0;
        foreach(Ingredient i in customer.WantedDrink.Ingredients)
        {
            foreach(Ingredient actualIngredient in actualDrink)
            {
                if (i.name == actualIngredient.Name)
                    desiredIngredientsCount++;
            }
        }
        if (desiredIngredientsCount < customer.WantedDrink.Ingredients.Count)
            return false;

        //checkear si todas las propiedades deseadas están
        int desiredPropertiesCount = 0;
        foreach (Ingredient.IngredientProperties ip in customer.WantedDrink.Properties)
        {
            foreach (Ingredient i in actualDrink)
            {
                foreach (Ingredient.IngredientProperties actualip in i.m_Properties)
                {
                    if (actualip == ip)
                        desiredPropertiesCount++;
                }
            }
        }
        if (desiredPropertiesCount < customer.WantedDrink.Properties.Count)
            return false;

        return true;

    }
}
