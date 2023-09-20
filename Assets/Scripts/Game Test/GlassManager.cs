using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : MonoBehaviour
{
    [SerializeField] int m_GlassSlots;  // ranuras de ingredientes del vaso
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    //[SerializeField] Ingredient ingredientResult; 
    private bool UnDrinkable;

    private Ingredient nextIngredient;
    public void AddIngredient(Ingredient ing)
    {
        if (ing.Type == IngredientType.Mixed)
            return;

        ingredients.Add(ing);
        m_GlassSlots += ing.SlotsOccupied;
    }

    public void MixIngredients()
    {
        Ingredient ingredientResult = ScriptableObject.CreateInstance<Ingredient>();
        ingredientResult.SlotsOccupied = m_GlassSlots;
        ingredientResult.Name = "Mezcla";

        Vector3 RGBColor = Vector3.zero;
        foreach(Ingredient ingredient in ingredients)
        {
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
        ingredientResult.Type = IngredientType.Mixed;
        ingredientResult.m_IngredientColor = new Color(RGBColor.x / ingredients.Count, RGBColor.y / ingredients.Count, RGBColor.z / ingredients.Count, 1);
        Debug.Log(ingredientResult.m_IngredientColor);
        GetComponent<SpriteRenderer>().color = ingredientResult.m_IngredientColor;
    }
}
