using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;

    public LayerMask WhatIsGround, WhatIsPlayer;

    // Patrolling
    public Vector3 walkPoint;
    private bool walkPointSet;
    public float walkPointRange;

    // Attacking
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    // States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake(){
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update(){
        // Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, WhatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, WhatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Patrolling();
        if(playerInSightRange && !playerInAttackRange) ChasePLayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    private void Patrolling(){
        if(!walkPointSet) SearchWalkPoint();
        if(walkPointSet) agent.SetDestination(walkPoint);

        // Check if player has reached the walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;
        // Walkpoint reached
        if(distanceToWalkPoint.magnitude < 1f) walkPointSet = false;
    }
    private void SearchWalkPoint(){
        // Calculate random point in range
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        // Set new Walkpoint
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y,transform.position.x + randomZ);
        // Check if walkpoint is inside the map
        if(Physics.Raycast(walkPoint, -transform.up, 2f, WhatIsGround)) walkPointSet = true;
    }

    private void ChasePLayer(){
        agent.SetDestination(player.position);
    }

    private void AttackPlayer(){
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
