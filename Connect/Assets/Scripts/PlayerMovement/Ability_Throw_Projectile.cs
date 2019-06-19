using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * 
 */
public class Ability_Throw_Projectile : MonoBehaviour
{
    public float speed;
    public Transform direction;
    public Transform projectileStartingPosition;

    [Header("Debug")]
    [SerializeField] private float radius;
    [SerializeField] private bool showProjPosition;

    [Header("Components")]
    [SerializeField] private GameObject projectile;
    [SerializeField] private InputControllerData playerControllKey;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(playerControllKey.ability1))
        {
            GameObject obj = GameObject.Instantiate(projectile, (Vector2)projectileStartingPosition.position, transform.rotation);
            obj.GetComponent<Rigidbody2D>().velocity = speed * (direction.position - projectileStartingPosition.position);
        }
    }

    private void OnDrawGizmos()
    {
        if(showProjPosition)
        {
            //Vector2 start = projectileStartingPosition - new Vector2(transform.position.x, transform.position.y);
            //Gizmos.DrawWireSphere(start, radius);
            Gizmos.DrawWireSphere(projectileStartingPosition.position, radius);
            Gizmos.DrawWireSphere(direction.position, radius);
            Gizmos.DrawLine(projectileStartingPosition.position, direction.position);
        }
    }
}
