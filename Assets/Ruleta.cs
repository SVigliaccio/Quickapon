using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ruleta : MonoBehaviour
{
    public GameObject textBox;
    public int number;
    
    public void Generate()
    {
        number = Random.Range(0, 7);
        textBox.GetComponent<Text>().text = "" + number;
    }



}
