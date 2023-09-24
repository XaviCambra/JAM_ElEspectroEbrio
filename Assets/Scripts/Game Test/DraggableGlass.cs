using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DraggableGlass : MonoBehaviour
{
    private Vector2 difference;
    private Vector3 initPosition;
    private GlassManager gm;
    [SerializeField]private Drink.GlassTypeEnum glassType;
    private void Start()
    {
        initPosition = transform.position;
    }
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
    }
    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint((Vector2)Input.mousePosition) - difference;
    }
    private void OnMouseUp()
    {
        transform.position = initPosition;
        if(gm != null)
        {
            gm.ChangeGlassType(glassType);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            gm = collision.gameObject.GetComponent<GlassManager>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "glass")
        {
            gm = null;
        }
    }
}
