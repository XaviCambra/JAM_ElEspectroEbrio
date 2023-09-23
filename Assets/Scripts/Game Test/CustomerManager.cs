using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    private Transform topX;
    [SerializeField]
    private TextMeshProUGUI customerDialogue;
    private bool customerEntranceFinished = true;
    private List<Client> customerList;
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
                transform.position += new Vector3(2, 0, 0);
            else
            {
                //TODO: el texto debe ser cargado desde un json y debe poderse pasar a otros diálogos
                customerDialogue.text = "¡ESTOY FURIOSA! Me acaba de dejar mi novio porque según él TENGO MUCHAS SERPIENTES EN LA CABEZA!!, ¿te lo puedes creer? Dame un alma malvada con algo mundano. ¡Pero nada espeso! Es tan asqueroso como mi ex.";
                customerEntranceFinished = true;
                customerIndex++;
            }
        }        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && customerEntranceFinished)
        {            
            Sprite sprite = Resources.Load<Sprite>(customerList[customerIndex].Sprite);
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
            new Client{ 
                Name = "Vampiro",
                Sprite = "Sprites/Vampiro",
                WantedIngredients = new List<IngredientOrder>
                {
                    new IngredientOrder
                    {
                        //Ingredient = new Ingredient("","",null,null,null,null,null),
                        Wanted = true,
                    }
                }
            },
            new Client{ },
        }; 
    }

    public bool ProcessOrder(Drink d)
    {
        var customer = customerList[customerIndex];
        foreach(var cond in customer.WantedDrinks)
        {
            if(cond.Want && cond.Drink != d)            
                return false;
            if (!cond.Want && cond.Drink == d)
                return false;
        }
        int wantedIngredients = customer.WantedIngredients.Count;
        int gotWantedIngredients = 0;
        foreach(IngredientOrder io in customer.WantedIngredients)
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
