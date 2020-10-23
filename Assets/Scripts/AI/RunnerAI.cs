using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RunnerAI : MonoBehaviour
{
	[Header("AI and Detection Variables")]
	public NavMeshAgent agent;
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

	[Header("Running Away Variables")]
	//Running Away
	public GameObject Player;

	// Start is called before the first frame update
	void Start()
	{
		agent = GetComponent<NavMeshAgent>();
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
			RunAway();
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


	private void RunAway()
	{
		Vector3 dirToClosestRunner = transform.position - Player.transform.position;
		Vector3 NewRunnerWalkPoint = transform.position + dirToClosestRunner;
		agent.SetDestination(NewRunnerWalkPoint);
	}

}