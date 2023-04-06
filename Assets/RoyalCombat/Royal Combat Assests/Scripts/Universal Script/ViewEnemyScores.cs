using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ViewEnemyScores : MonoBehaviour
{
    public TMP_Text  EnemyScoreBoard;
    
    void Start()
        {
        EnemyScoreBoard=GameObject.FindWithTag(Tags.Enemy_Score).GetComponent<TMP_Text>(); ;
        }

  public  void viewEnemyScore(float value)
        {
        EnemyScoreBoard.text=value.ToString();
        }

   
}
