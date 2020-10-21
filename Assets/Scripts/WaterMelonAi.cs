using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaterMelonAi : MonoBehaviour
{
	[Header("AI Variables and Detection Variables")]
	//AI Variables and Detection
	public NavMeshAgent agent;
	public GameObject WaterMelon;
	public LayerMask whatIsPlayer, whatIsGround;

	[Header("Patrolling Variables")]
	//Patrolling 
	public Vector3 walkPoint;
	bool walkPointSet;
	public float walkPointRange;

	[Header("AI States Variables")]
	//States
	public float sightRange, RunAwayRange;
	public bool CanSeePlayerInRange, CanRunAwayInRange;

	[Header("Finding the Player Variables")]
	//Finding the player
	public GameObject Player;

	[Header("Explosive WaterMelon Seeds Variables")]
	//ShootingINRandomDirections
	public Transform[] SeedPoints;
	public GameObject seed;
	public bool hasAttacked;
	public float AttackInterval;

	// Start is called before the first frame update
	void Start()
	{
		Player = GameObject.Find("Player");
	}

	// Update is called once per frame
	void Update()
	{
			

		CanRunAwayInRange = Physics.CheckSphere(transform.position, RunAwayRange, whatIsPlayer);



		if (!CanRunAwayInRange)
		{
			Patroling();
		}
		if (CanRunAwayInRange || CanSeePlayerInRange)
		{
			WalkTowardsPlayer();
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
			Debug.Log("test");
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


	private void WalkTowardsPlayer()
	{
		agent.SetDestination(Player.transform.position);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Player")
		{
			if (!hasAttacked)
			{
				for (int i = 0; i < SeedPoints.Length; i++)
				{
					Rigidbody rb = Instantiate(seed, SeedPoints[i].position, Quaternion.identity).GetComponent<Rigidbody>();
					Vector3 direction = SeedPoints[i].position - transform.position;
					rb.AddForce(direction * 4, ForceMode.Impulse);
					hasAttacked = true;
					Invoke(nameof(ResetAttack), AttackInterval);
					
				}
			}
		}
	}

	private void ResetAttack()
	{
		hasAttacked = false;
	}

}
