using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static int CustomersServed;
    public static int CustomersServedSuccessfully;
    public static string NextScene;
    public TextMeshProUGUI scoreDisplay;
    void Start()
    {
        if(scoreDisplay != null)
        {
            scoreDisplay.text = CustomersServedSuccessfully.ToString() + " / " + CustomersServed.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
