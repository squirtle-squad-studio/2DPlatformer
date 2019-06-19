using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCharacterSprite : MonoBehaviour
{
    [Header("Debug - State/Condition")]
    [SerializeField] private bool isLookingRight;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControllKey;

    // Start is called before the first frame update
    void Start()
    {
        if(playerControllKey == null) { Debug.Log("There isn't any playerControllKey attached"); }
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

        if(Input.GetKeyDown(playerControllKey.right) && !isLookingRight
            || Input.GetKeyDown(playerControllKey.left) && isLookingRight)
        {
            // flip
            //Vector3 v = transform.localScale;
            //v.x *= -1;
            //transform.localScale = v;

            //transform.rotation = Quaternion.Euler(0f,180f,0f);
            transform.Rotate(0, 180, 0);
        }

    }
}
