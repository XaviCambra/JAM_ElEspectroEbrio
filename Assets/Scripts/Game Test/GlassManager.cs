using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassManager : MonoBehaviour
{
    [SerializeField]
    private int slots;  // ranuras de ingredientes del vaso
    [SerializeField]
    private List<Ingredient> ingredients = new List<Ingredient>();
    private bool UnDrinkable;

    private Ingredient nextIngredient;
    public void AddIngredient(Ingredient ing)
    {
        if(ingredients.Count < slots)
        {
            //TODO: poner un check para mirar si el nuevo ingrediente es contrario al resto y poner UnDrinkable a true
            ingredients.Add(ing);
        }
    }
}
