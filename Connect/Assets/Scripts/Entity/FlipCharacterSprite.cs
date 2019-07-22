using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class flips the character to where it's moving.
 */
 [RequireComponent(typeof(EntityInput))]
public class FlipCharacterSprite : MonoBehaviour
{
    [Header("Debug - State/Condition")]
    [SerializeField] private bool isLookingRight;

    // Components
    private EntityInput entityInput;

    // Start is called before the first frame update
    void Start()
    {
        entityInput = GetComponent<EntityInput>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        isLookingRight = transform.rotation.eulerAngles.y < 0.01;

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------
        if(entityInput.right && !isLookingRight
            || entityInput.left && isLookingRight)
        {
            transform.Rotate(0, 180, 0);
        }
    }
}
