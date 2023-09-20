using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Vector2 difference;
    private GlassManager glassManager;
    private Ingredient ingredient;

    private Vector3 m_StartingPosition;

    private void Start()
    {
        ingredient = GetComponent<IngredientManager>().Ingredient;
        m_StartingPosition = transform.position;
    }
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        Instantiate(this, m_StartingPosition, Quaternion.Euler(0, 0, 0));
    }

    private void OnMouseUp()
    {
        if(glassManager != null)
        {
            glassManager.AddIngredient(ingredient);
        }
        Destroy(gameObject);
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - difference;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "glass")
        {
            glassManager = collision.gameObject.GetComponent<GlassManager>();            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            glassManager = null;
        }
    }
}
