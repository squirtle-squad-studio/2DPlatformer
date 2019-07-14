using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputControllerData keyInput;
    private EntityInput input;

    private void Awake()
    {
        input = GetComponent<EntityInput>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(keyInput.up))
        {
            input.up = true;
        }
        else if (Input.GetKeyUp(keyInput.up))
        {
            input.up = false;
        }

        if (Input.GetKeyDown(keyInput.down))
        {
            input.down = true;
        }
        else if (Input.GetKeyUp(keyInput.down))
        {
            input.down = false;
        }

        if (Input.GetKeyDown(keyInput.left))
        {
            input.left = true;
        }
        else if (Input.GetKeyUp(keyInput.left))
        {
            input.left = false;
        }

        if (Input.GetKeyDown(keyInput.right))
        {
            input.right = true;
        }
        else if (Input.GetKeyUp(keyInput.right))
        {
            input.right = false;
        }


        if (Input.GetKeyDown(keyInput.run))
        {
            input.run = true;
        }
        else if (Input.GetKeyUp(keyInput.run))
        {
            input.run = false;
        }

        if (Input.GetKeyDown(keyInput.jump))
        {
            input.jump = true;
        }
        else if (Input.GetKeyUp(keyInput.jump))
        {
            input.jump = false;
        }

        if (Input.GetKeyDown(keyInput.basicAttack))
        {
            input.basicAttack = true;
        }
        else if (Input.GetKeyUp(keyInput.basicAttack))
        {
            input.basicAttack = false;
        }

        if (Input.GetKeyDown(keyInput.ability1))
        {
            input.ability1 = true;
        }
        else if (Input.GetKeyUp(keyInput.ability1))
        {
            input.ability1 = false;
        }
    }
}
