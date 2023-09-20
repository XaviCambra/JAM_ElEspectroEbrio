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
        Mixed
    }
    public List<IngredientProperties> m_Properties = new List<IngredientProperties>();
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
    public IngredientTemperature m_Temperature;
    public enum IngredientTemperature
    {
        Frio,
        Neutro,
        Caliente
    }
    public Color m_IngredientColor;

    List<Ingredient> mixedIngredientList = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient)
    {
        mixedIngredientList.Add(ingredient);
    }

    public List<Ingredient> GetIngredientList()
    {
        return mixedIngredientList;
    }
}

public class Drink
{
    public List<Ingredient> Ingredients;
}