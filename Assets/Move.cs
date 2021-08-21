using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1000f * Time.deltaTime, 0, 0));
        }
        if (Input.GetKey("right"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1000f * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey("up"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, 1000f * Time.deltaTime));
        }

        if (Input.GetKey("down"))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -1000f * Time.deltaTime));
        }
    }
}
