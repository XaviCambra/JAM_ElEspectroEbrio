using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    [SerializeField] int m_GlassSlots;  // ranuras de ingredientes del vaso
    [SerializeField] List<Ingredient> ingredients = new List<Ingredient>();
    private bool UnDrinkable;

    private Ingredient nextIngredient;
    public void AddIngredient(Ingredient ing)
    {
        if(ing.SlotsOccupied < m_GlassSlots)
        {
            //TODO: poner un check para mirar si el nuevo ingrediente es contrario al resto y poner UnDrinkable a true
            ingredients.Add(ing);
            m_GlassSlots -= ing.SlotsOccupied;
        }
    }
}
