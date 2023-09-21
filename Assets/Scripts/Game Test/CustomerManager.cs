using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class CustomerManager : MonoBehaviour
{
    [SerializeField]
    private Transform topX;
    [SerializeField]
    private TextMeshProUGUI customerDialogue;
    private bool customerEntranceFinished;
    void FixedUpdate()
    {
        if (!customerEntranceFinished)
        {
            if (transform.position.x <= topX.transform.position.x)
                transform.position += new Vector3(2, 0, 0);
            else
            {
                //TODO: el texto debe ser cargado desde un json y debe poderse pasar a otros diálogos
                customerDialogue.text = "¡ESTOY FURIOSA! Me acaba de dejar mi novio porque según él TENGO MUCHAS SERPIENTES EN LA CABEZA!!, ¿te lo puedes creer? Dame un alma malvada con algo mundano. ¡Pero nada espeso! Es tan asqueroso como mi ex.";
                customerEntranceFinished = true;
            }
        }        
    }
}
