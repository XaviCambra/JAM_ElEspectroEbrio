using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    [SerializeField] protected Ingredient m_Ingredient;
    protected Draggable m_Draggable;

    private void Start()
    {
        m_Draggable = GetComponent<Draggable>();
    }

    private void Update()
    {
        if(m_Draggable != null)
            m_Draggable.enabled = m_Ingredient != null;
    }

    public virtual void AddIngredient(Ingredient l_IngredientToAdd) { }

    public virtual void Clear()
    {
        m_Ingredient = null;
    }

    public virtual void OnMouseUpToolAction() { }
}
