using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * if(player not detected) Zombie will patrol(walk) around the given area.
 * if(player detected AND not aggressive) Zombie turns aggressive.
 * if(player detected AND aggressive) Zombie have bigger playerDetector and starts running
 */
[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(AIInput))]
public class Zombie_Controller : MonoBehaviour
{
    [SerializeField] private Vector2 patrolLoc_left;
    [SerializeField] private Vector2 patrolLoc_right;

    [Header("Detectors")]
    [SerializeField] private PlayerDetector passiveDetector;
    [SerializeField] private PlayerDetector aggressiveDetector;

    [Header("Debug")]
    [Tooltip("Color for patrolLoc")]
    [SerializeField] private float radius;
    [SerializeField] private Color locColor;

    private bool isPatrolToTheRight;

    //[Header("Components")]
    private AIInput aiInput;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        aiInput = GetComponent<AIInput>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // state.passive
        if(animator.GetCurrentAnimatorStateInfo(1).IsName("Patrol"))
        {
            passiveDetector.collider.enabled = true;
            aggressiveDetector.collider.enabled = false;
            PatrolAroundLoc();
        }
        else if (animator.GetCurrentAnimatorStateInfo(1).IsName("Aggressive"))
        {
            passiveDetector.collider.enabled = false;
            aggressiveDetector.collider.enabled = true;

            GameObject closestPlayer = GetClosestPlayerFromTheDetector(aggressiveDetector);

            if (closestPlayer == null)
            {
                aiInput.aiControls.ResetKeyInputs();
                return;
            }
            else
            {
                float direction = closestPlayer.transform.position.x - transform.position.x;
                if (direction == 0)
                {
                    return;
                }
                else if(direction > 0)
                {
                    aiInput.aiControls.right = true;
                }
                else
                {
                    aiInput.aiControls.left = true;
                }
            }
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = locColor;

        Gizmos.DrawWireSphere(patrolLoc_left, radius);
        Gizmos.DrawWireSphere(patrolLoc_right, radius);
    }

    private void PatrolAroundLoc()
    {
        if(isPatrolToTheRight)
        {
            PatrolTo(patrolLoc_right);
        }
        else
        {
            PatrolTo(patrolLoc_left);
        }
    }

    private void PatrolTo(Vector2 loc)
    {
        aiInput.aiControls.ResetKeyInputs();
        if (loc.x - transform.position.x < 0.1 && loc.x - transform.position.x > -0.1)
        {
            TurnAround();
        }
        else if (loc.x - transform.position.x >= 0.1)
        {
            aiInput.aiControls.right = true;
        }
        else
        {
            aiInput.aiControls.left = true;
        }
    }

    private void TurnAround()
    {
        isPatrolToTheRight = !isPatrolToTheRight;
    }

    private GameObject GetClosestPlayerFromTheDetector(PlayerDetector detector)
    {
        GameObject closestPlayer;
        List<GameObject> listOfPlayers = detector.players;
        if (listOfPlayers.Count > 0)
        {
            closestPlayer = listOfPlayers[0];

            if (listOfPlayers.Count > 1)
            {
                float closestDistance = Vector3.Distance(listOfPlayers[0].transform.position, transform.position);
                for (int i = 1; i < listOfPlayers.Count; i++)
                {
                    if (Vector3.Distance(listOfPlayers[i].transform.position, transform.position) < closestDistance)
                    {
                        closestPlayer = listOfPlayers[i].gameObject;
                    }
                }
            }
        }
        else { return null; }
        return closestPlayer;
    }
}
