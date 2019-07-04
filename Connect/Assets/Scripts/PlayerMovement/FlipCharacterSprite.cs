using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This class flips the character to where it's moving.
 */
public class FlipCharacterSprite : MonoBehaviour
{
    [Header("AI")]
    [SerializeField] private bool useAI;

    [Header("Debug - State/Condition")]
    [SerializeField] private bool isLookingRight;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControllKey;
    private AIInput aiInput;

    // Start is called before the first frame update
    void Start()
    {
        if (useAI) { aiInput = GetComponent<AIInput>(); }
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

        if(useAI)
        {
            if (aiInput.aiControls.right && !isLookingRight
                || aiInput.aiControls.left && isLookingRight)
            {
                transform.Rotate(0, 180, 0);
            }
        }
        else
        {
            if(Input.GetKeyDown(playerControllKey.right) && !isLookingRight
                || Input.GetKeyDown(playerControllKey.left) && isLookingRight)
            {
                transform.Rotate(0, 180, 0);
            }
        }



    }
}
