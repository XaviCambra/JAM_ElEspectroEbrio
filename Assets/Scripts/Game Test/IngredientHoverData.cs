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
    private UnityEngine.UI.Image panel;
    private void Start()
    {
        im = GetComponent<IngredientManager>();
        var ingredientNameObject = GameObject.Find(PanelName);
        IngredientName = ingredientNameObject.GetComponentInChildren<TextMeshProUGUI>();
        panel = GameObject.Find(PanelName).GetComponent<UnityEngine.UI.Image>();
    }
    public void DisplayIngredientData(Vector2 newPosition)
    {
        if(im != null)
        {
            panel.enabled = true;
            IngredientName.enabled = true;
            IngredientName.text = im.Ingredient.name;
            IngredientName.transform.parent.position = Input.mousePosition;
        }
    }

    public void HideIngredientData()
    {
        panel.enabled = false;
        IngredientName.enabled = false;
    }
}