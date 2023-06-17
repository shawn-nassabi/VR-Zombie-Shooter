using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieStats : CharacterStats
{
    [SerializeField] private int damage;
    [SerializeField] public float attackSpeed;

    [SerializeField] private bool canAttack;
    private ZombieController thisZombie;

    private Animator anim = null;


    private void Start()
    {
        InitVariables();
    }

    public void DealDamage(CharacterStats statsToDamage)
    {
        //Damaging
        statsToDamage.TakeDamage(damage);
    }

    public override void Die()
    {
        base.Die();
        thisZombie.agent.isStopped = true;
        anim.SetTrigger("death");

        Destroy(gameObject,1.2f);

    }

    public override void InitVariables()
    {
        maxHealth = 25;
        SetHealthTo(maxHealth);
        isDead = false;

        damage = 10;
        attackSpeed = 1.5f;
        canAttack = true;
        anim = GetComponent<Animator>();
        thisZombie = GetComponent<ZombieController>();
    }
}
