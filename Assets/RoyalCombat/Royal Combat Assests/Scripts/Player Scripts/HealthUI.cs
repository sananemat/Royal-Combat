using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    private Image health_UI;
    private Image enemy_health_UI;
    private ViewPlayerScores playerScore;
    private ViewEnemyScores enemyScore;
    // Start is called before the first frame update
    void Awake()
    {
        health_UI=GameObject.FindWithTag(Tags.HEALTH_UI).GetComponent<Image>();
        enemy_health_UI=GameObject.FindWithTag(Tags.Enemy_HEALTH_UI).GetComponent<Image>();
        playerScore=GetComponent<ViewPlayerScores>();
        enemyScore=GetComponent<ViewEnemyScores>();
        }

   public void DisplayHealth(float value)
        {
        value/=100f;

        if (value < 0f)
            value = 0f;

        health_UI.fillAmount=value;
        playerScore.viewPlayerScore(value*100);

        }
    public void EnemyDisplayHealth(float value)
        {
        value/=100f;

        if (value<0f)
            value=0f;

        enemy_health_UI.fillAmount=value;
        enemyScore.viewEnemyScore(value*100);
        }

}
