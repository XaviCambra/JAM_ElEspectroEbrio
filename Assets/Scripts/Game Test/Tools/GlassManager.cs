using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : MonoBehaviour
{
    [SerializeField] List<Sprite> glassSprites; // order is chupito, martini, rocks, tubo
    [SerializeField] private bool UnDrinkable;
    [SerializeField] private Drink drink;
    [SerializeField] private int maxSlots;
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
        GetComponent<SpriteRenderer>().sprite = null;
    }

    public void ChangeGlassType(Drink.GlassTypeEnum glassType)
    {
        Clear();
        drink.GlassType = glassType;
        switch (glassType)
        {
            case Drink.GlassTypeEnum.Shot:
                GetComponent<SpriteRenderer>().sprite = glassSprites[0];
                maxSlots = 1;
                break;
            case Drink.GlassTypeEnum.Martini:
                GetComponent<SpriteRenderer>().sprite = glassSprites[1];
                maxSlots = 3;
                break;
            case Drink.GlassTypeEnum.Rocks:
                GetComponent<SpriteRenderer>().sprite = glassSprites[2];
                maxSlots = 4;
                break;
            case Drink.GlassTypeEnum.Tube:
                GetComponent<SpriteRenderer>().sprite = glassSprites[3];
                maxSlots = 6;
                break;
        }
    }
}
