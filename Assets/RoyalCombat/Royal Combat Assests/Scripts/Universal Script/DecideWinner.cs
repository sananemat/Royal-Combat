using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideWinner : MonoBehaviour
{
    public GameObject winpanel,losepanel;
  
    // Start is called before the first frame update
    void Start()
    {
        winpanel.SetActive(false);
        losepanel.SetActive(false);
      
        }

    public void SetWinner()
        {
        winpanel.SetActive(true);
       
     
        }
    public void Setloser()
        {
        losepanel.SetActive(true);
      
        }
    }
