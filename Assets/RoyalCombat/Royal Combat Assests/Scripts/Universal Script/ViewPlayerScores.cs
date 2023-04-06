using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewPlayerScores : MonoBehaviour
{
    public TMP_Text PlayerScoreBoard;
    void Awake()
        {
        PlayerScoreBoard=GameObject.FindWithTag(Tags.Player_Score).GetComponent<TMP_Text>();
        }

 
   public void viewPlayerScore(float value)
        {
        PlayerScoreBoard.text=value.ToString();
        }
 

   
}
