using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColour : MonoBehaviour
{
    public InputField inputField;


    public void changeColor()
        {
        inputField.placeholder.color = Color.black;
        }
}
