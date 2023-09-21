using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class IngredientManager : MonoBehaviour
{
    public Ingredient Ingredient;
    SpriteRenderer m_Sprite;
    private void Start()
    {
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Sprite.sprite = Ingredient.m_Sprite;
    }
}
