using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int ID;
    public string type;
    public string descripcion;
    public Sprite icon;
    public int value;
    public Unit Player;
    [HideInInspector] //Para que una variable publica no se visualice en unity
    public bool picketUp;
    [HideInInspector]
    public bool equipped;

    [HideInInspector]
    public GameObject weaponManager;

    [HideInInspector]
    public GameObject equipment;


    public bool playersWeapon;

    private void Start()
    {
        Player = GetComponentInParent<Unit>();
        weaponManager = GameObject.FindWithTag("WeaponManager");

        if (!playersWeapon)
        {
            int allweapons = weaponManager.transform.childCount;
            for (int i = 0; i < allweapons; i++)
            {
                if (weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().ID == ID)
                {
                    value = weaponManager.transform.GetChild(i).gameObject.GetComponent<Item>().value;
                    equipment = weaponManager.transform.GetChild(i).gameObject;
                }
            }
        }
    }

    private void Update()
    {
        if (equipped)
        {
            if (Input.GetKeyDown(KeyCode.E)){
                equipped = false;
            }
            if (equipped == false)
            {
                gameObject.SetActive(false);
               
                if (type == "Weapon")Unit.damage -= value;
                
                if (type == "Shield") Unit.defence -= value;
            }
        }
    }
    public void ItemUsage()
    {
        if (type == "Weapon")
        {
            
            equipment.SetActive(true);
            if (Unit.damage != Unit.dañoBase) { Unit.damage = Unit.dañoBase; }
            equipment.GetComponent<Item>().equipped = true;
            if (type == "Weapon") Unit.damage += value;
            if (type == "Shield") Unit.defence += value;
        }
        if (type == "Shield")
        {
            
            equipment.SetActive(true);
            if (Unit.defence != 0) { Unit.defence = 0; }
            equipment.GetComponent<Item>().equipped = true;
            Unit.defence += value;
        }

    }

    public void DeleteItem()
    {
        if (type == "Weapon")
        {
            equipment.SetActive(false);

            equipment.GetComponent<Item>().equipped = false;
            equipment.GetComponent<Item>().icon = null;
        }
        if (type == "Shield")
        {
            equipment.SetActive(false);

            equipment.GetComponent<Item>().equipped = false;
            equipment.GetComponent<Item>().icon = null;
        }

    }
}
