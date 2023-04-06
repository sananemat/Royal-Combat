using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    private TextMeshPro textmesh;
    private void Awake()
        {
        textmesh=GetComponent<TextMeshPro>();
        gameObject.AddComponent<TextMeshPro>();
        textmesh.color=Color.blue;
        }

    /* public InputField inputField;


     public void changeColor()
         {
         inputField.placeholder.color = Color.black;
         }*/
    }
