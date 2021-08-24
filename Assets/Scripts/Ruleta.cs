using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ruleta : MonoBehaviour
{
    //public NavMeshController jugador;
    public GameObject textBox;
    public int number=0;
    
   // public GameObject[] Fichas;
    public void Start()
    {
        //Fichas = GameObject.FindGameObjectsWithTag("Fichas");
      
    }

    public void Generate()
    {
        number = Random.Range(0, 7);
       
        textBox.GetComponent<Text>().text = "" + number;
        /*if (number==0)
        {
            jugador.caminar = false;
        }
        else
        {
            //jugador.caminar = true;
        }*/
        

    }
    


}
