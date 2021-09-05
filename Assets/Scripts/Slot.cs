using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerClickHandler
{
    public GameObject item;
    public int ID;
    public string type;
    public string descripcion;

    public bool empty;
    public Sprite icon;


    public Transform slotIconGameObject;
    private Transform OpcionesGameObject;
    private Transform EquiparGameObject;
    private Transform EliminarGameObject;
    private bool opcEnabled;
    private Sprite iconDefault;


    private void Start()
    {
        opcEnabled = false;
        slotIconGameObject = gameObject.transform.GetChild(0);
        iconDefault = slotIconGameObject.GetComponent<Image>().sprite; //guardo el background que viene por defecto para no asociarlo a null cuando remueva los items del slot y que quede un fondo blanco.
        OpcionesGameObject = gameObject.transform.GetChild(1); //Lo necesito para mostrar u ocultar las opciones de los slots.
        EquiparGameObject = OpcionesGameObject.gameObject.transform.GetChild(0);
        EliminarGameObject = OpcionesGameObject.gameObject.transform.GetChild(1);
        EquiparGameObject.GetComponent<Button>().onClick.AddListener(UseItem);
        EliminarGameObject.GetComponent<Button>().onClick.AddListener(RemoveItem);
    }
    public void UpdateSlot()
    {
        slotIconGameObject.GetComponent<Image>().sprite = icon;
    }

    public void UseItem()
    {
        item.GetComponent<Item>().ItemUsage();
        OpcionesGameObject.gameObject.SetActive(false);
    }

    public void RemoveItem()
    {
        item.GetComponent<Item>().DeleteItem();// que lo desactive si está equipado
        Inventory.DelItem(gameObject);// que lo elimine del inventario
        slotIconGameObject.GetComponent<Image>().sprite = iconDefault;
        OpcionesGameObject.gameObject.SetActive(false);
        Destroy(gameObject.transform.GetChild(2).gameObject);
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (item.GetComponent<Item>().icon != null) // que active o desactive las opciones cuando el icono no sea null. o sea, cuando haya un item en el slot.
        {
            opcEnabled = !opcEnabled;
            if (opcEnabled)
            {
                OpcionesGameObject.gameObject.SetActive(true);
            }
            else
            {
                OpcionesGameObject.gameObject.SetActive(false);
            }
        }
    }
}
