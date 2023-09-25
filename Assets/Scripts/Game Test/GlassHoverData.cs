using TMPro;
using UnityEngine;

/// <summary>
/// Gets Ingredient information and shows it in a UI panel
/// </summary>
public class GlassHoverData : MonoBehaviour
{
    const string PanelName = "IngredientsDataPanel";

    private GlassManager gm;
    private TextMeshProUGUI IngredientName;
    private UnityEngine.UI.Image panel;

    private bool showData = false;
    private void Start()
    {
        gm = GetComponent<GlassManager>();
        var ingredientNameObject = GameObject.Find(PanelName);
        IngredientName = ingredientNameObject.transform.parent.GetComponentInChildren<TextMeshProUGUI>();
        panel = GameObject.Find(PanelName).GetComponent<UnityEngine.UI.Image>();
    }
    public void DisplayGlassData(Vector2 newPosition)
    {
        showData = true;        
    }
    private void OnMouseEnter()
    {
        showData = true;
    }

    private void OnMouseExit()
    {
        showData=false;
        HideIngredientData();
    }

    private void Update()
    {
        if (showData)
        {
            if (gm != null)
            {
                panel.enabled = true;
                IngredientName.enabled = true;
                string glassData = "";
                glassData += gm.GetDrink().GlassType.ToString();                              
                for(int i=0; i < gm.maxSlots; i++)
                {
                    if (i < gm.GetDrink().Ingredients.Count) 
                    {
                        glassData += "\n -" + gm.GetDrink().Ingredients[i].name;
                    }
                    else
                    {
                        glassData += "\n -";
                    }
                   
                }
                IngredientName.SetText(glassData);
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