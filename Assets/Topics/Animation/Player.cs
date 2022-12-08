using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 moveDirection = Vector3.zero;
    public float speed = 1.0F;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            moveDirection = new Vector3(0, 0, -1);
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("w"))
        {
            moveDirection = new Vector3(0, 0, 1);
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("a"))
        {
            moveDirection = Vector3.left; //new Vector3(-1, 0, 0);
            moveDirection *= speed;
            controller.Move(moveDirection);
        }

        if (Input.GetKeyDown("d"))
        {
            moveDirection = Vector3.right; //new Vector3(1, 0, 0);
            moveDirection *= speed;
            controller.Move(moveDirection);
        }
    }
}
