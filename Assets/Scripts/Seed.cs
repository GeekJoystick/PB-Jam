using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Invoke(nameof(DestroyThis), 5f);
		}

		if(collision.gameObject.tag == "Player")
		{
			/*Health health = collision.gameObject.GetComponent<Health>();
			if (health)
			{
				health.Hurt();
			}
			Destroy(gameObject);*/
		}

	}


	public void DestroyThis()
	{
		Destroy(gameObject);
	}

}
