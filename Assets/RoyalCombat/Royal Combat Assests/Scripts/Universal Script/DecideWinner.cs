using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideWinner : MonoBehaviour
{
    public GameObject winimage,loseimage;
    // Start is called before the first frame update
    void Start()
    {
        winimage.SetActive(false);
        loseimage.SetActive(false);
    }

    public void SetWinner()
        {
        winimage.SetActive(true);
        }
    public void Setloser()
        {
        loseimage.SetActive(true);
        }
    }
