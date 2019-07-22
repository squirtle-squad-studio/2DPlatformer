using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class instantiates a given projectile and launches it.
 * This class also has individual actions for the animator to use.
 */

[RequireComponent(typeof(EntityInput))]
public class Ability_Throw_Projectile : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    public float speed;
    public Transform direction;
    public Transform projectileStartingPosition;
    public float cooldownTimer;

    [Header("Animator parameters Variables")]
    [SerializeField] private bool useAnimator;
    [SerializeField] private string abilityName;

    [Header("Debug")]
    [SerializeField] private float radius;
    [SerializeField] private bool showProjPosition;
    [SerializeField] private GameObject recentProjectile;

    [Header("Components")]
    private EntityInput entityKeys;
    private Animator animator;

    private Cooldown cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = new Cooldown(0);
        animator = GetComponent<Animator>();
        entityKeys = GetComponent<EntityInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown.isOnCD())
        {
            return;
        }
        if(entityKeys.ability1)
        {
            if (animator != null && useAnimator)
            {
                animator.SetTrigger(abilityName);
            }
            else if (!useAnimator || animator == null)
            {
                InstantiateAndLaunchProjectile();
            }
            cooldown.NextCD(cooldownTimer);
        }
    }

    private void InstantiateAndLaunchProjectile()
    {
        InstantiateProjectile();
        LaunchProjectile();
    }

    private void LaunchProjectile()
    {
        if(recentProjectile != null)
        {
            // Debug.DrawLine(transform.position, speed * (direction.position - projectileStartingPosition.position + transform.position)); // Debug
            recentProjectile.GetComponent<Rigidbody2D>().velocity = speed * (direction.position - projectileStartingPosition.position).normalized;
        }
    }

    private void InstantiateProjectile()
    {
        recentProjectile = GameObject.Instantiate(projectilePrefab, (Vector2)projectileStartingPosition.position, transform.rotation);
    }

    private void OnDrawGizmos()
    {
        if(showProjPosition)
        {
            Gizmos.DrawWireSphere(projectileStartingPosition.position, radius);
            Gizmos.DrawWireSphere(direction.position, radius);
            Gizmos.DrawLine(projectileStartingPosition.position, direction.position);
        }
    }
}
