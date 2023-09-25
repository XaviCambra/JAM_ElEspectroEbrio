using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Ingredient;
public class JiggerController : Tools
{
    private GlassManager gm;
    public override void AddIngredient(Ingredient l_IngredientToAdd)
    {
        if (l_IngredientToAdd.Type == IngredientType.Liquid)
        {
            m_Ingredient = ScriptableObject.CreateInstance<Ingredient>();
            m_Ingredient.name = l_IngredientToAdd.IngredientName;
            m_Ingredient.SlotsOccupied = l_IngredientToAdd.SlotsOccupied;
            m_Ingredient.IngredientName = l_IngredientToAdd.IngredientName;
            m_Ingredient.Description = l_IngredientToAdd.Description;
            Debug.Log(m_Ingredient.IngredientName);
            m_Ingredient.m_Properties = new List<IngredientProperties>();
            foreach (IngredientProperties property in l_IngredientToAdd.m_Properties)
            {
                if (!m_Ingredient.m_Properties.Contains(property))
                {
                    m_Ingredient.m_Properties.Add(property);
                }
            }
            m_Ingredient.m_Temperature = l_IngredientToAdd.m_Temperature;
            m_Ingredient.m_IngredientColor = l_IngredientToAdd.m_IngredientColor;
            m_Ingredient.Type = IngredientType.Jiggled;
            m_Draggable.AddIngredient(m_Ingredient);
        }
    }

    public override void OnMouseUpToolAction()
    {
        if(gm != null)
            gm.AddIngredient(m_Ingredient);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.name == "GlassManager")
        {
            gm = collision.gameObject.GetComponent<GlassManager>();
        }
    }
}
