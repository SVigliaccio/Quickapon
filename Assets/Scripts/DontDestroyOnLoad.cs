using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// COLOCAR SCRIPT EN PREFAB/OBJETOS EN CASO DE UN SOLO PREFAB DEL TIPO EN ESCENA
/// EN CASO DE MULTIPLES PREFABS DEL MISMO NOMBRE, CREAR PADRE EMPTYOBJECT Y INSERTAR PREFAB DENTRO, CON EL SCRIPT EN SU NUEVO PADRE
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    [HideInInspector]
    public string objectID;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    
    void Start()
    {
        for (int i = 0; i< Object.FindObjectsOfType<DontDestroyOnLoad>().Length; i++)
        {
            
            if(Object.FindObjectsOfType<DontDestroyOnLoad>()[i] != this) 
            {
                
                if (Object.FindObjectsOfType<DontDestroyOnLoad>()[i].objectID == objectID)
                {
                    
                    Destroy(gameObject);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
