using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JiggerController : MonoBehaviour
{
    [SerializeField] Ingredient m_Ingredient;

    public void AddIngredient(Ingredient l_IngredientToAdd)
    {
        if(m_Ingredient.Type == Ingredient.IngredientType.Liquid)
        {
            m_Ingredient = l_IngredientToAdd;
        }
    }
}
