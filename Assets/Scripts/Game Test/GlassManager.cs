using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : MonoBehaviour
{
    [SerializeField] int m_GlassSlots;
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    [SerializeField] SpriteRenderer m_ColorResultTest;
    [SerializeField] List<Sprite> glassSprites; // order is chupito, martini, rocks, tubo
    private bool UnDrinkable;
    private Drink drink;
    private int maxSlots;

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
        //if (m_Ingredient != null)
          //  return;

        //if (ing.Type == IngredientType.Mixed ||   // TODO: preguntar por qué estaba esto
          //  ing.Type == IngredientType.Liquid)
            //return;
        if(maxSlots < drink.Ingredients.Count)
        {
            drink.Ingredients.Add(ing);
            m_GlassSlots += ing.SlotsOccupied;
            if (ing.m_Temperature == Ingredient.IngredientTemperature.Frio)
                drink.Temperature = IngredientTemperature.Frio;
            if (ing.m_Temperature == Ingredient.IngredientTemperature.Caliente)
                drink.Temperature = IngredientTemperature.Caliente;

        }
        else
        {
            // alertar de que el vaso está lleno
        }
       
    }

    // esto tendría que estar en el script de coctelera??
    public void MixIngredients()
    {
        Ingredient ingredientResult = ScriptableObject.CreateInstance<Ingredient>();
        ingredientResult.SlotsOccupied = m_GlassSlots / 2;
        m_GlassSlots = 0;
        ingredientResult.Name = "";

        Vector3 RGBColor = Vector3.zero;
        ingredientResult.mixedIngredientList = new List<Ingredient>();
        ingredientResult.m_Properties = new List<IngredientProperties>();
        ingredientResult.mixedIngredientList = new List<Ingredient>();
        foreach (Ingredient ingredient in drink.Ingredients)
        {
            if (ingredient == ingredients[ingredients.Count - 1])
                ingredientResult.Name += ingredient.Name;
            else
                ingredientResult.Name += ingredient.Name + " con ";

            ingredientResult.AddIngredient(ingredient);
            foreach(IngredientProperties property in ingredient.m_Properties)
            {
                if (!ingredientResult.m_Properties.Contains(property))
                {
                    ingredientResult.m_Properties.Add(property);
                }
            }

            RGBColor.x += ingredient.m_IngredientColor.r;
            RGBColor.y += ingredient.m_IngredientColor.g;
            RGBColor.z += ingredient.m_IngredientColor.b;
        }
        ingredientResult.name = ingredientResult.Name;
        ingredientResult.Type = IngredientType.Mixed;
        ingredientResult.m_IngredientColor = new Color(RGBColor.x / ingredients.Count, RGBColor.y / ingredients.Count, RGBColor.z / ingredients.Count, 1);
        m_ColorResultTest.color = ingredientResult.m_IngredientColor;
        ingredients.Clear();
        //m_Ingredient = ingredientResult;
        //m_Draggable.AddIngredient(m_Ingredient);
    }

    private void OnMouseDown()
    {
        if(ingredients.Count >= 2)
        {
            MixIngredients();
        }
    }

    public void Clear()
    {
        drink.Ingredients = new List<Ingredient>();
        drink.Temperature = IngredientTemperature.Neutro;
    }

    public void ChangeGlassType(Drink.GlassTypeEnum glassType)
    {
        Clear();
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
