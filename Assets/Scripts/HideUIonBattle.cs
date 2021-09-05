using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HideUIonBattle : MonoBehaviour
{
    public Canvas HUD;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name== "BattleScene" || SceneManager.GetActiveScene().name == "FinalBattle")
        {
            HUD.GetComponent<Canvas>().enabled = false;
        }
        else
        {
            HUD.GetComponent<Canvas>().enabled = true;
        }
    }
}
