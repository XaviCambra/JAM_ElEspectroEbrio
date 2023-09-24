using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverEffect : MonoBehaviour
{
    private IngredientHoverData ihd;
    private void Start()
    {
        ihd = GetComponent<IngredientHoverData>();
    }
    private void OnMouseEnter()
    {
        transform.localScale = transform.localScale * 1.25f;
        if(ihd != null)
        {
            ihd.DisplayIngredientData((Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
    }

    private void OnMouseExit()
    {
        transform.localScale = transform.localScale * 0.8f;
        if (ihd != null)
        {
            ihd.HideIngredientData();
        }
    }
}
