using TMPro;
using UnityEngine;

/// <summary>
/// Gets Ingredient information and shows it in a UI panel
/// </summary>
public class IngredientHoverData : MonoBehaviour
{
    const string PanelName = "IngredientsDataPanel";

    private IngredientManager im;
    private TextMeshProUGUI IngredientName;
    private void Start()
    {
        im = GetComponent<IngredientManager>();
        IngredientName = GameObject.Find(PanelName).GetComponentInChildren<TextMeshProUGUI>();
    }
    public void DisplayIngredientData(Vector2 newPosition)
    {
        Debug.Log(newPosition);
        if(im != null)
        {
            IngredientName.text = im.Ingredient.name;
            IngredientName.transform.parent.position = Input.mousePosition;
        }
    }
}