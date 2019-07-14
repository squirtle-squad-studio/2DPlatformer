using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityInput : MonoBehaviour
{
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    public bool run;

    public bool jump;

    public bool basicAttack;
    public bool ability1;

    public void ResetKeyInputs()
    {
        up = false;
        down = false;
        left = false;
        right = false;

        run = false;

        basicAttack = false;
    }
}
