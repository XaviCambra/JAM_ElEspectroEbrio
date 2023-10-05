using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : MonoBehaviour
{
    [SerializeField] List<GameObject> glassObjects;
    [SerializeField] private bool UnDrinkable;
    [SerializeField] private Drink drink;
    [SerializeField] public int maxSlots;
    [SerializeField] Drink.GlassTypeEnum glassTypeEnum;

    private void Start()
    {
        drink = new Drink();
        maxSlots = 6;
    }
    public Drink GetDrink()
    {
        return drink;
    }
    public List<Ingredient> GetIngredients()
    {
        return drink.Ingredients;
    }

    public void AddIngredient(Ingredient ing)
    {
        if(drink.Ingredients.Count < maxSlots)
        {
            drink.Ingredients.Add(ing);
            foreach(IngredientProperties property in ing.m_Properties)
            {
                drink.Properties.Add(property);
            }
            if (ing.m_Temperature == Ingredient.IngredientTemperature.Frio)
                drink.Temperature = IngredientTemperature.Frio;
            if (ing.m_Temperature == Ingredient.IngredientTemperature.Caliente)
                drink.Temperature = IngredientTemperature.Caliente;
        }
       
    }

    public void Clear()
    {
        drink.Ingredients = new List<Ingredient>();
        drink.Temperature = IngredientTemperature.Neutro;
        drink.Properties = new List<IngredientProperties>();
        GetComponent<SpriteRenderer>().sprite = null;
    }

    public void ChangeGlassType(Drink.GlassTypeEnum glassType)
    {
        Clear();
        drink.GlassType = glassType;
        foreach(GameObject l_Glass in glassObjects)
        {
            if(l_Glass.GetComponent<DraggableGlass>().GetGlassType() == glassType)
            {
                l_Glass.SetActive(true);
            }
            else
            {
                l_Glass.SetActive(false);
            }
        }
    }
}
