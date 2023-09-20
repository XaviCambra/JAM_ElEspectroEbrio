using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = ("Ingredientes/Nuevo Ingrediente"), order = 1)]
public class Ingredient : ScriptableObject
{
    public string Name;
    public string Description;
    public IngredientType Type;
    [Tooltip("Numero de slots que ocupa. En los líquidos siempre es 1")] public int SlotsOccupied;
    public enum IngredientType
    {
        Liquid,
        Solid,
        Grain,
        Decoration  //opcional
    }
    public IngredientProperties[] m_Properties;
    public enum IngredientProperties
    {
        Fuerte,
        Suave,
        Espeso,
        Ligero,
        Vivo,
        Necrótico,
        Bloody,
        Magic,
        Mundano
    }
}

public class Drink
{
    public List<Ingredient> Ingredients;
}