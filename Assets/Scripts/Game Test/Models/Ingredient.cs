using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Ingredient
{
    public int Name;
    public string Description;
    public IngredientType Type;
    public int SlotsOccupied;    // tiene que ser siempre 1 para líquidos
    public enum IngredientType
    {
        Liquid,
        Solid,
        Grain,
        Decoration  //opcional
    }
    
}