using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basic_Attack : MonoBehaviour
{
    public float cooldownTime;
    [Header("Animator parameters Variables")]
    [SerializeField] private string basicAttackName;

    // Cooldown
    private Cooldown cooldown;

    [Header("Components")]
    private EntityInput entityKeys;
    private Animator animator;

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
        if(entityKeys.basicAttack && animator != null && !cooldown.isOnCD())
        {
            animator.SetTrigger(basicAttackName);
            cooldown.NextCD(cooldownTime);
        }
    }
}
