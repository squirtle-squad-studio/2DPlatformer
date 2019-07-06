using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Attack : MonoBehaviour
{
    [Header("AI")]
    [Tooltip("Please have AIController component attached")]
    public bool useAI;

    [Header("Animator parameters Variables")]
    [SerializeField] private string basicAttackName;

    [Header("Components")]
    [SerializeField] private InputControllerData playerControllKey;
    private Animator animator;
    private AIInput aiInput;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        if (useAI) { aiInput = GetComponent<AIInput>(); }
    }

    // Update is called once per frame
    void Update()
    {
        if(useAI)
        {
            if(aiInput.aiControls.basic_attack && animator != null)
            {
                animator.SetTrigger(basicAttackName);
            }
        }
        else
        {
            if(Input.GetKeyDown(playerControllKey.basicAttack) && animator != null)
            {
                animator.SetTrigger(basicAttackName);
            }
        }

    }
}
