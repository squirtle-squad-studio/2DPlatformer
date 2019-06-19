using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Touch_Destroy : MonoBehaviour
{
    private Collider2D collider;
    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject.Destroy(this);
    }
}
