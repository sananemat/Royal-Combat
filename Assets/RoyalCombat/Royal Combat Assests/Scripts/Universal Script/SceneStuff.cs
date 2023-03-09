using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneStuff : MonoBehaviour
{
    public int SceneNumber;  
    

    public void GoNextScene ()
        {
        SceneManager.LoadScene(SceneNumber);
        }

    
}
