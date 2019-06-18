using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacterSprite : MonoBehaviour
{
    [Header("Debug - State/Condition")]
    [SerializeField] private bool isLookingRight;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControllKey;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        isLookingRight = true;
        if(playerControllKey == null) { Debug.Log("There isn't any playerControllKey attached"); }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //--------------------------------------------------------------
        // Updates player condition
        //--------------------------------------------------------------
        isLookingRight = spriteRenderer.flipX == false;

        //--------------------------------------------------------------
        // Execute action based on conditions
        //--------------------------------------------------------------

        if(Input.GetKeyDown(playerControllKey.right) && !isLookingRight
            || Input.GetKeyDown(playerControllKey.left) && isLookingRight)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

    }
}
