using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    private NavMeshAgent agente;
    // Start is called before the first frame update
    void Start()
    {
        /*
         FUNCIONAMIENTO:
         Al iniciarse este script, detecte el componente NavMeshAgent dentro de nuestro jugador
        y que haga que nos movamos directamente hasta el objetivo.
         */
        //Queremos acceder al componente NavMeshAgent que a�adimos con antelacion a nuestro jugador.
        agente = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Si hacemos click con el boton 0 del mouse(que es el que corresponde con el boton izquierdo)
        if (Input.GetMouseButtonDown(0))
        {
            //creamos una variable RaycastHit para almacenar la posicion donde se hizo click con el mouse. .
            RaycastHit hit;
            //Comprobar si ese rayo que vamos a crear est� tocando en alguna parte
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