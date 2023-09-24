using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Ingredient", menuName = ("Ingredientes/Nuevo Ingrediente"), order = 1)]
public class Ingredient : ScriptableObject
{
    public Ingredient(string name, string description, IngredientType type, List<IngredientProperties> ingredientProperties, IngredientTemperature temperature, Color color, Sprite sprite)
    {
        Name = name;
        Description = description;
        Type = type;
        m_Properties = ingredientProperties;
        m_Temperature = temperature;
        m_IngredientColor = color;
        m_Sprite = sprite;
    }

    public Ingredient(Ingredient ingredient)
    {
        Name = ingredient.Name;
        Description = ingredient.Description;
        Type = ingredient.Type;
        m_Properties = ingredient.m_Properties;
        m_Temperature = ingredient.m_Temperature;
        m_IngredientColor = ingredient.m_IngredientColor;
        m_Sprite = ingredient.m_Sprite;
    }

    public string Name;
    public string Description;
    public IngredientType Type;
    [Tooltip("Numero de slots que ocupa. En los l�quidos siempre es 1")] public int SlotsOccupied;
    public enum IngredientType
    {
        Liquid,
        Jiggled,
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
        Indiferente,
        Frio,
        Neutro,
        Caliente        
    }
    public Color m_IngredientColor;

    public Sprite m_Sprite;

    public List<Ingredient> mixedIngredientList = new List<Ingredient>();
    public void AddIngredient(Ingredient ingredient)
    {
        mixedIngredientList.Add(ingredient);
    }

    public List<Ingredient> GetIngredientList()
    {
        return mixedIngredientList;
    }
}

public class IngredientOrder
{
    public Ingredient Ingredient;
    public bool Wanted;
}

public class IngredientPropertyOrder
{
    public Ingredient.IngredientType IngredientType;
    public bool Wanted;
}

public class Drink
{
    [TextArea(1, 5)] public string TextDescriptionKey;
    public List<Ingredient> Ingredients;
    public List<Ingredient.IngredientProperties> Properties;
    public List<Ingredient> UndesiredIngredients;
    public List<Ingredient.IngredientProperties> UndesiredProperties;
    public Ingredient.IngredientTemperature Temperature;

    public Drink() 
    { 
        Ingredients = new List<Ingredient>();
        Properties = new List<Ingredient.IngredientProperties>();
        UndesiredIngredients = new List<Ingredient>();
        UndesiredProperties = new List<Ingredient.IngredientProperties>();
    }
}