using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableGlass : MonoBehaviour
{
    private Vector2 m_Difference;
    private Vector3 m_InitPosition;
    private GlassManager m_GlassManager;
    [SerializeField] private Drink.GlassTypeEnum m_GlassType;
    private void Start()
    {
        m_InitPosition = transform.position;
    }
    private void OnMouseDown()
    {
        m_Difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - m_Difference;
    }
    private void OnMouseUp()
    {
        transform.position = m_InitPosition;
        if(m_GlassManager != null)
        {
            m_GlassManager.ChangeGlassType(m_GlassType);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            m_GlassManager = collision.gameObject.GetComponent<GlassManager>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            m_GlassManager = null;
        }
    }

    public Drink.GlassTypeEnum GetGlassType()
    {
        return m_GlassType;
    }
}
