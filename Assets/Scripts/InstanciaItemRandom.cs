using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciaItemRandom : MonoBehaviour
{
   
    public Transform pos_instancia;
    public GameObject[] items;
    //public Ruleta Mov;
    // Start is called before the first frame update
    void Start()
    {
        instanciarObjeto();
    }

    private void instanciarObjeto()
    {
        int numRand = Random.Range(0, items.Length);
        Instantiate(items[numRand], pos_instancia.position, items[numRand].transform.rotation, pos_instancia);
    }
    
}
