using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_Capsule_Trigger_Destroy : MonoBehaviour
{
    private CapsuleCollider2D collider;
    private void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Destroy(this.gameObject);
    }
}
