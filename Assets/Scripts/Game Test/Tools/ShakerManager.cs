using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ingredient;

public class ShakerManager : Tools
{
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();

    public override void AddIngredient(Ingredient ing)
    {
        if (m_Ingredient != null)
            return;
        if (ing.Type == IngredientType.Mixed ||   // TODO: preguntar por qu� estaba esto
          ing.Type == IngredientType.Liquid)
            return;
        if (ingredients.Contains(ing) &&
            ing.Type == IngredientType.Solid)
            return;

        ingredients.Add(ing);
    }

    // esto tendr�a que estar en el script de coctelera??
    public void MixIngredients()
    {
        Ingredient ingredientResult = ScriptableObject.CreateInstance<Ingredient>();
        ingredientResult.mixedIngredientList = new List<Ingredient>();
        ingredientResult.m_Properties = new List<IngredientProperties>();
        ingredientResult.mixedIngredientList = new List<Ingredient>();
        ingredientResult.IngredientName = "";

        Vector3 RGBColor = Vector3.zero;
        bool l_IsCold = false;
        bool l_IsHot = false;
        foreach (Ingredient ingredient in ingredients)
        {
            if (ingredient == ingredients[ingredients.Count - 1])
                ingredientResult.IngredientName += ingredient.IngredientName;
            else
                ingredientResult.IngredientName += ingredient.IngredientName + " con ";

            if(ingredient.m_Temperature == IngredientTemperature.Frio)
                l_IsCold = true;
            if(ingredient.m_Temperature == IngredientTemperature.Caliente)
                l_IsHot = true;

            ingredientResult.SlotsOccupied += ingredient.SlotsOccupied / 2;
            ingredientResult.AddIngredient(ingredient);
            foreach (IngredientProperties property in ingredient.m_Properties)
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
        if (l_IsCold && !l_IsHot)
            ingredientResult.m_Temperature = IngredientTemperature.Frio;
        else if (!l_IsCold && l_IsHot)
            ingredientResult.m_Temperature = IngredientTemperature.Caliente;
        else
            ingredientResult.m_Temperature = IngredientTemperature.Neutro;

        ingredientResult.name = ingredientResult.IngredientName;
        ingredientResult.Type = IngredientType.Mixed;
        ingredientResult.m_IngredientColor = new Color(RGBColor.x / ingredients.Count, RGBColor.y / ingredients.Count, RGBColor.z / ingredients.Count, 1);

        ingredients.Clear();
        m_Ingredient = ingredientResult;
        m_Draggable.AddIngredient(m_Ingredient);
    }

    private void OnMouseDown()
    {
        if (ingredients.Count >= 2)
        {
            MixIngredients();
        }
    }
}
