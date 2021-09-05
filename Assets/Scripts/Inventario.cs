using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    public List<GameObject> Bag = new List<GameObject>();
    public GameObject inv;
    public bool Activar_inv;

    public GameObject Selector;
    public int ID;

    public GameObject Opciones;
    public Image[] Seleccion;
    public Sprite[] Seleccion_Sprite;
    public int ID_Select=0;
    public int ID_equipo=0; //12->Arma, 13->Escudo, 14->Especial
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item"))
        {
            for (int i = 0; i < Bag.Count; i++)
            {
                if (Bag[i].GetComponent<Image>().enabled == false)
                {
                    Bag[i].GetComponent<Image>().enabled = true;
                    Bag[i].GetComponent<Image>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                    break;
                }
            }
            // si el tag es item, que se equipe en Especial
            ID_equipo = 14;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Selector.SetActive(true);
        Opciones.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Navegar();
        if (Activar_inv)
        {
            inv.SetActive(true);
        }
        else
        {
            inv.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Activar_inv = !Activar_inv;
        }
    }

    public void Navegar()
    {
        if(Input.GetKeyDown(KeyCode.D) && ID < Bag.Count - 1)
        {
            ID++;
        }
        if(Input.GetKeyDown(KeyCode.A) && ID > 0)
        {
            ID--;
        }
        if(Input.GetKeyDown(KeyCode.W) && ID > 3)
        {
            ID-=4;
        }
        if (Input.GetKeyDown(KeyCode.S) && ID <  12)
        {
            ID += 4;
        }
   

        Selector.transform.position = Bag[ID].transform.position;
        
        //Selector.SetActive(true);
        //Opciones.SetActive(false);

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (Bag[ID].CompareTag("Item"))
            {
                ID_equipo = 14;
            }
            /*else if (Bag[ID].CompareTag("Escudo"))
            {
                ID_equipo = 13;
            }
            else if (Bag[ID].CompareTag("Arma"))
            {
                ID_equipo = 12;
            }*/
            else
            {
                ID_equipo = 0;
            }

            
            Opciones.SetActive(true);
            
            Selector.SetActive(false);
            print("Pasa por acá"+ID_Select);
            //Que se mueva el selector en opciones.
            if (Input.GetKeyDown(KeyCode.W) && ID_Select > 0)
            {
                ID_Select--;
                print("Pasa por acá");
            }

            if (Input.GetKeyDown(KeyCode.S) && ID_Select <  Seleccion.Length - 1)
            {
                ID_Select++;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Opciones.SetActive(false);
                Opciones.transform.position = Bag[ID].transform.position;
                Selector.SetActive(true);
            }
            Opciones.transform.position = Bag[ID].transform.position;

            switch (ID_Select)
            {
                case 0: //Equiparse
                    
                    
                        Seleccion[0].sprite = Seleccion_Sprite[1];
                        Seleccion[1].sprite = Seleccion_Sprite[0];
                        
                        if (Input.GetKeyDown(KeyCode.F) && ID_equipo != 0)
                        {
                       
                            if (Bag[ID_equipo].GetComponent<Image>().enabled == false)
                            {
                                Bag[ID_equipo].GetComponent<Image>().sprite = Bag[ID].GetComponent<Image>().sprite;
                                Bag[ID_equipo].GetComponent<Image>().enabled = true;
                                Bag[ID].GetComponent<Image>().sprite = null;
                                Bag[ID].GetComponent<Image>().enabled = false;
                            }
                            else
                            {
                                Sprite obj = Bag[ID].GetComponent<Image>().sprite;

                                Bag[ID].GetComponent<Image>().sprite = Bag[ID_equipo].GetComponent<Image>().sprite;
                                Bag[ID_equipo].GetComponent<Image>().sprite = obj;
                            }

                        Selector.SetActive(true);
                        Opciones.SetActive(false);
                        }

                    print(ID_equipo + ", fin de seleccion");
                    break;


                case 1://Eliminar
                    Seleccion[0].sprite = Seleccion_Sprite[0];
                    Seleccion[1].sprite = Seleccion_Sprite[1];

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Bag[ID].GetComponent<Image>().sprite = null;
                        Bag[ID].GetComponent<Image>().enabled = false;

                        Selector.SetActive(true);
                        Opciones.SetActive(false);
                    }
                    break;

            }

        }

    }
}
