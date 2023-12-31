using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Button Pressed Menu SFX")]
    [field: SerializeField] public EventReference buttonPressedMenu { get; private set; }
    [field: Header("Button Over Menu SFX")]
    [field: SerializeField] public EventReference buttonOverMenu { get; private set; }
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }
    }
}
