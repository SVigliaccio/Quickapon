using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnload : MonoBehaviour
{
    private void Awake()
    {
        //para destruir el dontDestroyOnLoad en el menu principal, ya que cuando vamos del lvl al menu se queda guardado en el menu y no queremos eso jhm. Queremos que se resetee
        var noDestruirEntreEscenas = FindObjectsOfType<LogicaEntreEscenas>();
            foreach( LogicaEntreEscenas DontDestroy in noDestruirEntreEscenas)
            {
                Destroy(DontDestroy.gameObject);
            }
            
            return;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
