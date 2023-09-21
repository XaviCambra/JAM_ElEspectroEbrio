using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static Ingredient;

public class GlassManager : Tools
{
    [SerializeField] int m_GlassSlots;
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    private bool UnDrinkable;

    public override void AddIngredient(Ingredient ing)
    {
        if (m_Ingredient != null)
            return;

        if (ing.Type == IngredientType.Mixed ||
            ing.Type == IngredientType.Liquid)
            return;

        ingredients.Add(ing);
        m_GlassSlots += ing.SlotsOccupied;
    }

    public void MixIngredients()
    {
        Ingredient ingredientResult = ScriptableObject.CreateInstance<Ingredient>();
        ingredientResult.SlotsOccupied = m_GlassSlots / 2;
        ingredientResult.Name = "";

        Vector3 RGBColor = Vector3.zero;
        ingredientResult.mixedIngredientList = new List<Ingredient>();
        ingredientResult.m_Properties = new List<IngredientProperties>();
        foreach (Ingredient ingredient in ingredients)
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
        ingredients.Clear();
        m_Ingredient = ingredientResult;
    }

    private void OnMouseDown()
    {
        if(ingredients.Count >= 2)
        {
            MixIngredients();
        }
    }

    public override void Clear()
    {
        base.Clear();
        ingredients = new List<Ingredient>();
    }
}
