using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 difference;
    Tools m_Tool;
    [SerializeField] GlassManager m_GlassManager;
    [SerializeField] ShakerManager m_ShakerManager;
    [SerializeField] JiggerController m_JiggerController;
    [SerializeField] StrainerManager m_StrainerManager;
    [SerializeField] GarbageManager m_GarbageManager;
    public Ingredient m_Ingredient;
    public bool isJigger;

    private Vector3 m_StartingPosition;

    private void Start()
    {
        try
        {
            m_Ingredient = GetComponent<IngredientManager>().Ingredient;
        }
        catch (System.Exception) { }
        try
        {
            m_Tool = GetComponent<Tools>();
        }
        catch (System.Exception) { }

        m_StartingPosition = transform.position;
    }
    private void OnMouseDown()
    {
        if(gameObject.GetComponent<Draggable>().enabled)
            difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }

    private void OnMouseUp()
    {
        if (m_GlassManager != null && m_Ingredient.Type == Ingredient.IngredientType.Solid)
        {
            m_GlassManager.AddIngredient(m_Ingredient);
            if (m_Tool != null)
                m_Tool.Clear();
        }
        /*if (m_ShakerManager != null)
        {
            m_ShakerManager.AddIngredient(m_Ingredient);
            if (m_Tool != null)
                m_Tool.Clear();
        }*/
        if (m_JiggerController != null)
        {
            if(!isJigger)
                m_JiggerController.AddIngredient(m_Ingredient);
            //if (m_Tool != null)
              //  m_Tool.Clear();
            if(isJigger)
                m_JiggerController.OnMouseUpToolAction();
        }
        if(m_StrainerManager != null)
        {
            m_StrainerManager.AddIngredient(m_Ingredient);
            if (m_Tool != null)
                m_Tool.Clear();
        }
        
        transform.position = m_StartingPosition;
    }

    private void OnMouseDrag()
    {
        if (gameObject.GetComponent<Draggable>().enabled)
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - difference;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "glass")
        {
            m_GlassManager = collision.gameObject.GetComponent<GlassManager>();
        }
        if (collision.tag == "Shaker")
        {
            m_ShakerManager = collision.gameObject.GetComponent<ShakerManager>();
        }
        if (collision.name == "Medidor")
        {
            m_JiggerController = collision.gameObject.GetComponent<JiggerController>();
        }
        if (collision.tag == "Strainer")
        {
            m_StrainerManager = collision.gameObject.GetComponent<StrainerManager>();
        }
        if(collision.tag == "Garbage")
        {
            m_GarbageManager = collision.gameObject.GetComponent<GarbageManager>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            m_GlassManager = null;
        }
    }

    public void AddIngredient(Ingredient ingredient)
    {
        m_Ingredient = ingredient;
    }
}
