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

    private bool showData;
    private void Start()
    {
        im = GetComponent<IngredientManager>();
        var ingredientNameObject = GameObject.Find(PanelName);
        IngredientName = ingredientNameObject.transform.parent.GetComponentInChildren<TextMeshProUGUI>();
        panel = GameObject.Find(PanelName).GetComponent<UnityEngine.UI.Image>();
    }
    public void DisplayIngredientData(Vector2 newPosition)
    {
        showData = true;
        
    }

    private void Update()
    {
        if (showData)
        {
            if (im != null)
            {
                panel.enabled = true;
                IngredientName.enabled = true;
                string ingredientData = im.Ingredient.name;
                if (ingredientData == "Hielo")
                {
                    ingredientData += "\n  - Enfría las bebidas";
                }
                if (ingredientData == "Esquirlas de Lava")
                {
                    ingredientData += "\n  - Calienta las bebidas";
                }
                foreach (Ingredient.IngredientProperties property in im.Ingredient.m_Properties)
                {
                    ingredientData += "\n  - " + property.ToString();
                }
                
                IngredientName.SetText(ingredientData);
                IngredientName.ForceMeshUpdate();               

                IngredientName.transform.parent.position = Input.mousePosition;

                Vector2 textSize = IngredientName.GetRenderedValues(false);
                panel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, IngredientName.renderedHeight + 20);
            }
        }
    }

    public void HideIngredientData()
    {
        showData=false;
        panel.enabled = false;
        IngredientName.enabled = false;
    }
}