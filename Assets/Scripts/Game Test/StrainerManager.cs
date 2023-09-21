using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ingredient;

public class StrainerManager : Tools
{
    public override void AddIngredient(Ingredient ing)
    {
        if (ing.Type != IngredientType.Mixed)
            return;
        
        Debug.Log("Peso antes: " + ing.SlotsOccupied);

        foreach (Ingredient ingredient in ing.GetIngredientList())
        {
            if(ingredient.Type == IngredientType.Solid)
            {
                ing.SlotsOccupied -= ingredient.SlotsOccupied/2;
            }
        }

        Debug.Log("Peso después: " + ing.SlotsOccupied);
        m_Ingredient = ing;
        m_Draggable.AddIngredient(m_Ingredient);
    }
}
