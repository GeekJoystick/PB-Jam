using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

	[Header("AI Detection Variables")]
	public NavMeshAgent agent;

	public Transform Player;

	public GameObject PotatoShooter;

	public CharacterController controller;

	public GameObject Potato;

	public LayerMask whatIsPlayer, whatIsGround;

	[Header("Patrolling Variables")]
	//Patrolling 
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	[Header("Attacking Variables")]
	//Attacking
	public float AttackInterval;
	bool hasAttacked;

	[Header("AI States Variables")]
	//States
	public float sightRange, attackRange;
	public bool CanSeePlayerInRange, CanAttackPlayerInRange;

	public AudioSource PotatoPop;
	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		Player = GameObject.Find("Player").transform;
		PotatoPop = GameObject.Find("PotatoPop").GetComponent<AudioSource>();
	}

	void Update()
	{
		//Checks if the player is in sight and attack range
		CanSeePlayerInRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
		CanAttackPlayerInRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

		if (!CanSeePlayerInRange && !CanAttackPlayerInRange)
		{
			Patroling();
		}
		if (CanSeePlayerInRange)
		{
			ChasePlayer();
		}
		if (CanSeePlayerInRange && CanAttackPlayerInRange)
		{
			AttackPlayer();
		}
	}

	private void Patroling()
	{
		if (!walkPointSet)
		{
			SearchWalkPoint();
		}

		if (walkPointSet)
		{
			agent.SetDestination(walkPoint);
		}

		Vector3 distanceToWalkPoint = transform.position - walkPoint;

		//Walkpoint Reached
		if (distanceToWalkPoint.magnitude < 1f)
		{
			walkPointSet = false;
		}
	}

	private void SearchWalkPoint()
	{
		//Calculate random point in range
		float randomZ = Random.Range(-walkPointRange, walkPointRange);
		float randomX = Random.Range(-walkPointRange, walkPointRange);

		walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

		//Shoots raycast down the position of the set way point and then goes to it.
		if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
		{
			walkPointSet = true;
		}
	}

	private void ChasePlayer()
	{
		//makes the potato go to the player 
		agent.SetDestination(Player.transform.position);
	}

	private void AttackPlayer()
	{
		//looks at the player
		transform.LookAt(Player);

		if (!hasAttacked)
		{
			//Shoot bean man :o
			Rigidbody rb = Instantiate(Potato, PotatoShooter.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
			rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
			rb.AddForce(transform.up * 2f, ForceMode.Impulse);

			//Makes the potato shoot again - potatoessss
			hasAttacked = true;
			Invoke(nameof(ResetAttack), AttackInterval);

			if (!PotatoPop.isPlaying)
			{
				PotatoPop.Play();
			}
		}
	}


	private void ResetAttack()
	{
		//resets attack
		hasAttacked = false;
	}
}
