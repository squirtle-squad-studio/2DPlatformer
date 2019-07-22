using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    public int MyHealth
    {
        get
        {
            return health;
        }
        set
        {
            if (health + value < 0)
            {
                health = 0;
            }
            else
            {
                health = value;
            }
        }
    }
}
