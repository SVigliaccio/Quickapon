using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnabledObject : MonoBehaviour
{
    //public bool objEnabled;
    // Start is called before the first frame update
    public GameObject inventory;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void enabledObject()
    {
        
            Inventory.inventoryEnabled = !Inventory.inventoryEnabled;
        if (Inventory.inventoryEnabled)
        {
            inventory.SetActive(true);
        }
        else
        {
            inventory.SetActive(false);
        }
    }
}
