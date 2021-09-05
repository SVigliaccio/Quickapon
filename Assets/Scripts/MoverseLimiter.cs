using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MoverseLimiter : MonoBehaviour
{
    
    public Button boton;
    // Start is called before the first frame update
    void Start()
    {
        boton.onClick.AddListener(Limiter);
    }
    
    public void Limiter()
    {
        if (boton.interactable == true)
        {
            boton.interactable = false;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name != "Level2")
        {
            boton.interactable = true;
        }
    }
}
