using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonOverMenu);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonPressedMenu);
    }
}
