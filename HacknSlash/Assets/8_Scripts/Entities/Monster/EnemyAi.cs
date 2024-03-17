using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [Header("References")]
    // public
    public GameObject stateIndicator;
    public LayerMask WhatIsGround, WhatIsPlayer;
    // private
    private Renderer stateRenderer;
    private NavMeshAgent agent;
    private Transform player;

    [Header("State Settings")]
    // public
    public float sightRange, attackRange;
    // private
    private bool playerInSightRange;
    private bool playerInAttackRange;

    [Header("Idle State Settings")]
    // public
    public float waitingTimeMin;
    public float waitingTimeMax;
    public Color idleColorIndicator = Color.green;
    // private
    private float waitingTime;
    private bool idle = true;
    private bool IsIdling;

    [Header("Patrolling State Settings")]
    // public
    public Vector3 walkPoint;
    public float walkPointRange;
    public Color patrollingColorIndicator = Color.blue;
    // private
    private bool walkPointSet = false;

    [Header("Chase Player State Settings")]
    // public
    public Color chasePlayerColorIndicator = Color.magenta;

    [Header("Attacking State Settings")]
    // public
    public float timeBetweenAttacks;
    public Color attackColorIndicator = Color.red;
    // private
    private bool alreadyAttacked;

    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        stateRenderer = stateIndicator.GetComponent<Renderer>();
    }

    private void Update(){
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        // GetState
        if(!playerInSightRange && !playerInAttackRange && idle && !IsIdling) Idle();
        if(!playerInSightRange && !playerInAttackRange && !idle) Patrolling();
        if(playerInSightRange && !playerInAttackRange) ChasePLayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Idle(){
        IsIdling = true;
        waitingTime = Random.Range(waitingTimeMin, waitingTimeMax);
        stateRenderer.material.color = idleColorIndicator;
        StartCoroutine(IdleWait());
    }

    private IEnumerator IdleWait(){
        yield return new WaitForSeconds(waitingTime);
        idle = false;
        IsIdling = false;
    }

    private void Patrolling(){
        stateRenderer.material.color = patrollingColorIndicator;
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) agent.SetDestination(walkPoint);

        // Check if AI has reached the walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        if(distanceToWalkPoint.magnitude < 1f){
            walkPointSet = false;
            idle = true;
        }
    }
    
    bool SearchWalkPoint(){
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = transform.position + Random.insideUnitSphere * walkPointRange;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                walkPoint = hit.position;
                walkPointSet = true;
                return true;
            }
        }
        walkPoint = Vector3.zero;
        return false;
    }

    private void ChasePLayer(){
        stateRenderer.material.color = chasePlayerColorIndicator;
        agent.SetDestination(player.position);
        transform.LookAt(new Vector3 (player.position.x, transform.position.y, player.position.z));
    }

    private void AttackPlayer(){
        stateRenderer.material.color = attackColorIndicator;
        // Make Sure enemy doesn't move
        agent.SetDestination(transform.position);
        transform.LookAt(new Vector3 (player.position.x, transform.position.y, player.position.z));

        if(!alreadyAttacked){
            // Attack code
            Attack();
            // 
            alreadyAttacked =true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    public virtual void Attack(){

    }

    private void ResetAttack(){
        alreadyAttacked = false;
    }
}
