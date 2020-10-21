using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Invoke(nameof(DestroyThis), 5f);
		}
		else if (collision.gameObject.tag == "Bean")
		{
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime){
				spawner.time = spawner.maxTime;
			}
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "Peanut")
		{
			GameObject peanut = collision.gameObject.GetComponent<PeanutAI>().peanut;
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime){
				spawner.time = spawner.maxTime;
			}
			spawner.AddObject(Instantiate(peanut, collision.gameObject.transform.position, collision.gameObject.transform.localRotation));
			spawner.AddObject(Instantiate(peanut, collision.gameObject.transform.position, collision.gameObject.transform.localRotation));
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
	}


	private void DestroyThis ()
	{
			Destroy(this.gameObject);
	}

}
