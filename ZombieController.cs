using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieController : MonoBehaviour
{

    public NavMeshAgent agent = null;
    public Transform target;
    [SerializeField] private float stoppingDistance = 2f;

    private float timeOfLastAttack = 0;
    private ZombieStats stats = null;
    private bool hasReachedPlayer = false;

    // Animation stuff
    private Animator anim = null;

    private void Start()
    {
        GetReferences();
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        agent.SetDestination(target.position);
        anim.SetFloat("Speed", 1f, 0.3f, Time.deltaTime);

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget <= stoppingDistance)
        {
            RotateToTarget();
        }


        if (distanceToTarget <= stoppingDistance)
        {
            anim.SetFloat("Speed", 0f);
            // Attack

            if (hasReachedPlayer = false)
            {
                hasReachedPlayer = true;
                timeOfLastAttack = Time.time;
            }

            if(Time.time >= timeOfLastAttack + stats.attackSpeed)
            {
                timeOfLastAttack = Time.time;
                CharacterStats targetStats = target.GetComponent<CharacterStats>();
                AttackTarget(targetStats);
            }

        }
        else
        {
            if(hasReachedPlayer)
            {
                hasReachedPlayer = false;
            }
        }

    }

    private void RotateToTarget()
    {
        transform.LookAt(target);
    }

    private void GetReferences()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        stats = GetComponent<ZombieStats>();
        target = PlayerScript.instance;
    }

    private void AttackTarget(CharacterStats statsToDamage)
    {
        anim.SetTrigger("attack");
        stats.DealDamage(statsToDamage);
    }

}
