using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Vector3 up = Vector3.zero,
    right = new Vector3(0, -90, 0),
    down = new Vector3(0, 180, 0),
    left = new Vector3(0, 90, 0),
    currentDirection = Vector3.zero;
    Vector3 nextPos, destination, direction;
    public float speed = 15f;
    public bool canMove;
    float rayLength = 1f;


    void Start()
    {
        currentDirection = up;
        nextPos = Vector3.forward;
        destination = transform.position;
    }


    void Update()
    {
        move();
    }

    void move()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.W))
        {
            nextPos = Vector3.forward;
           // currentDirection = up;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            nextPos = Vector3.back;
            //currentDirection = down;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            nextPos = Vector3.left;
            //currentDirection = left;
            canMove = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            nextPos = Vector3.right;
            //currentDirection = right;
            canMove = true;
        }

        if (Vector3.Distance(destination, transform.position) <= 0.000001f)
        {
            //transform.localEulerAngles = currentDirection;
            if (canMove)
            {
                if (Detect())
                {
                    destination = transform.position + nextPos;
                    direction = nextPos;
                    canMove = false;
                }
            }

        }

        


    }
    public bool Detect()
    {
        Ray myRay = new Ray(transform.position + new Vector3(0, 0.02f, 0), transform.forward);
        RaycastHit hit;
        Debug.DrawRay(myRay.origin, myRay.direction, Color.cyan); ///Para debugear
        if (Physics.Raycast(myRay, out hit, rayLength))
        {
            if (hit.collider.tag == "Wall")
            {
                return false;
            }
        }
        return true;
    }





}
