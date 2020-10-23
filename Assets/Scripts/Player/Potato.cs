using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
	bool active;

	public AudioSource WatermelonSound;
	public AudioSource PeanutSound;
	void Awake(){
		active = true;
		WatermelonSound = GameObject.Find("WaterMelonSound").GetComponent<AudioSource>();
		PeanutSound = GameObject.Find("PeanutSound").GetComponent<AudioSource>();
	}
	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Invoke(nameof(DestroyThis), 5f);
		}

		if (collision.gameObject.tag == "Bean")
		{
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime)
			{
				spawner.time = spawner.maxTime;
			}
			Food food = collision.gameObject.GetComponent<Food>();
			if (food != null)
			{
				food.Die();
			}
			spawner.score += 100;
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}
		else if (collision.gameObject.tag == "BigPeanut")
		{
			GameObject peanut = collision.gameObject.GetComponent<PeanutAI>().peanut;
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime)
			{
				spawner.time = spawner.maxTime;
			}

			spawner.score += 250;
			spawner.AddObject(Instantiate(peanut, collision.gameObject.transform.position, collision.gameObject.transform.localRotation));
			spawner.AddObject(Instantiate(peanut, collision.gameObject.transform.position, collision.gameObject.transform.localRotation));
			Destroy(gameObject);
			Destroy(collision.gameObject);

			if (!PeanutSound.isPlaying)
			{
				PeanutSound.Play();
				Debug.Log("BigPeanut");
			}
		}
		else if (collision.gameObject.tag == "WaterMelon")
		{
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime)
			{
				spawner.time = spawner.maxTime;
			}
			spawner.score += 500;
			Food food = collision.gameObject.GetComponent<Food>();
			if (food != null)
			{
				food.Die();
			}
			Destroy(gameObject);
			Destroy(collision.gameObject);
			if (!WatermelonSound.isPlaying)
			{
				Debug.Log("WaterMelon");
				WatermelonSound.Play();
			}
		}
		else if (collision.gameObject.tag == "SmallPeanut")
		{
			BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
			spawner.time += spawner.timePerBean;
			if (spawner.time > spawner.maxTime)
			{
				spawner.time = spawner.maxTime;
			}
			spawner.score += 125;
			Food food = collision.gameObject.GetComponent<Food>();
			if (food != null)
			{
				food.Die();
			}
			Destroy(gameObject);
			Destroy(collision.gameObject);
			if (!PeanutSound.isPlaying)
			{
				PeanutSound.Play();
				Debug.Log("SmallPeanut");
			}
		}
		else if (collision.gameObject.tag == "Potato")
		{
			if (gameObject.tag == "Player")
			{
				BeanManager spawner = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
				spawner.time += spawner.timePerBean;
				if (spawner.time > spawner.maxTime)
				{
					spawner.time = spawner.maxTime;
				}
				spawner.score += 200;
				Food food = collision.gameObject.GetComponent<Food>();
			if (food != null)
			{
				food.Die();
			}
				Destroy(gameObject);
				Destroy(collision.gameObject);
			}
		}
		active = false;
		if (gameObject.tag == "WaterMelon" || gameObject.tag == "Potato")
		{
				Debug.Log("active");
				if (collision.gameObject.tag == "Player")
				{
					Health health = collision.gameObject.GetComponent<Health>();
					if (health)
					{
						health.Hurt();
					}
					Destroy(gameObject);
				}
			}
		}

		
	


	private void DestroyThis ()
	{
			Destroy(this.gameObject);
	}

}
