using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class NavMeshController : MonoBehaviour
{
    public bool caminar=false;
    private NavMeshAgent agente;
    public Ruleta Mov;
    public SceneChanger escena;
    
    // Start is called before the first frame update
    void Start()
    {
        /*
         FUNCIONAMIENTO:
         Al iniciarse este script, detecte el componente NavMeshAgent dentro de nuestro jugador
        y que haga que nos movamos directamente hasta el objetivo.
         */
        //Queremos acceder al componente NavMeshAgent que añadimos con antelacion a nuestro jugador.
        agente = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Mov.number > 0 && FindObjectOfType<MoverseLimiter>().boton.interactable == false) { caminar = true;  } else { caminar = false; agente.destination = gameObject.transform.position; }

        if (caminar)
        {
            //Si hacemos click con el boton 0 del mouse(que es el que corresponde con el boton izquierdo)
            if (Input.GetMouseButtonDown(0))
            {
                //creamos una variable RaycastHit para almacenar la posicion donde se hizo click con el mouse. .
                RaycastHit hit;
                //Comprobar si ese rayo que vamos a crear está tocando en alguna parte
                //Llamamos al sistema de fisicas, generamos un raycast(rayo invisible) y vamos a decirle que
                //en la camara principal cree un screen point to ray. Esto lo que hace es crear un rayo directamente
                //directamente desde el punto que nosotros tengamos el cursor del raton(input.mousePosition) de la pantalla hacia el mundo.
                //se manda como parametro la varibale hit para almacenar la posicion donde estamos haciendo click con el raton en nuestra pantalla. 
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    //decimos al agente que su destino sea igual al punto en la pantalla en la cual se encuentra.
                    agente.destination = hit.point;
                    
                }
                

            }
        }
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Fichas" || other.tag == "FichaPuerta" || other.tag == "FichaCiudad"
            || other.tag == "FichaCofrePlateado" || other.tag == "FichaAlas" || other.tag == "FichaCofreEquipo")
        {
            if (Mov.number > 0) //si los movimientos restantes son mayores a 0, entonces que le reste 1.
            {
                Mov.number -= 1; 
            }

            if(Mov.number == 0 && other.tag == "Fichas")
            {
                Mov.number = 2;
                escena.ChangeScene("BattleScene");
                
            }
            if (Mov.number == 0 && other.tag == "FichaCiudad")
            {
                Mov.number = 2;
                escena.ChangeScene("FinalBattle");

            }
        }
        print("Mov al caminar: " + Mov.number);
    }
}
