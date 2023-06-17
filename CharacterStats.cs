using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{

    //#region

    //public static Transform instance;

   // private void Awake()
    //{
    //    instance = this.transform;
    //}

    //#endregion

    [SerializeField] protected int health;
    [SerializeField] protected int maxHealth = 100;
    [SerializeField] protected bool isDead = false;



    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }


    public void CheckHealth()
    {
        if(health <= 0)
        {
            health = 0;
            Die();
        }
        if (health >= maxHealth)
        {
            health = maxHealth;
        }
    }

    public virtual void Die()
    {
        isDead = true;
    }

    public void SetHealthTo(int healthToSetTo)
    {
        health = healthToSetTo;
        CheckHealth();
    }

    public void TakeDamage(int damage)
    {
        int healthAfterDamage = health - damage;
        SetHealthTo(healthAfterDamage);
    }

    public void Heal(int heal)
    {
        int healthAfterHeal = health + heal;
        SetHealthTo(healthAfterHeal);
    }

    public virtual void InitVariables()
    {
        maxHealth = 100;
        SetHealthTo(maxHealth);
        isDead = false;
    }

}
