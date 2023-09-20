using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : MonoBehaviour
{
    [SerializeField] int m_GlassSlots;
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    private bool UnDrinkable;

    [SerializeField] IngredientManager m_IngredientManager;

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
        ingredientResult.SlotsOccupied = m_GlassSlots / 2;
        ingredientResult.Name = "Mezcla";

        Vector3 RGBColor = Vector3.zero;
        foreach(Ingredient ingredient in ingredients)
        {
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
        ingredientResult.Type = IngredientType.Mixed;
        ingredientResult.m_IngredientColor = new Color(RGBColor.x / ingredients.Count, RGBColor.y / ingredients.Count, RGBColor.z / ingredients.Count, 1);

        m_IngredientManager.Ingredient = ingredientResult;
    }
}
