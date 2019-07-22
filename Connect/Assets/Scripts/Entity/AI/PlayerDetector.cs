using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Detects players by using triggers.
 * 1) Stores the players in a list
 * 2) Notifies the animator that it has detected at least a player
 */
public class PlayerDetector : MonoBehaviour
{
    public List<GameObject> players { get; private set; }

    [Header("Animator parameters Variables")]
    [SerializeField] string varToTrue;

    [HideInInspector] public Collider2D collider;
    //private Animator animator;
    private void Start()
    {
        players = new List<GameObject>();
        //animator = GetComponentInParent<Animator>();
        collider = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            players.Add(collision.gameObject);
            //animator.SetBool(varToTrue, true);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            players.Remove(collision.gameObject);

            if(players.Count == 0)
            {
                //animator.SetBool(varToTrue, false);
            }
        }
    }
}
