using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Attack : MonoBehaviour
{
    [Header("Animator parameters Variables")]
    [SerializeField] private string basicAttackName;

    [Header("Components")]
    private EntityInput entityKeys;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        entityKeys = GetComponent<EntityInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(entityKeys.basicAttack && animator != null)
        {
            animator.SetTrigger(basicAttackName);
        }
    }
}
