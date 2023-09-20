using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverEffect : MonoBehaviour
{
    private void OnMouseEnter()
    {
        transform.localScale = transform.localScale * 1.25f;
    }

    private void OnMouseExit()
    {
        transform.localScale = transform.localScale * 0.8f;
    }
}
