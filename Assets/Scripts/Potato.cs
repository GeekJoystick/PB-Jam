using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Invoke(nameof(DestroyThis), 5f);
		}
		if (collision.gameObject.tag == "Bean")
		{
			Invoke(nameof(DestroyThis), 5f);
			Destroy(collision.gameObject);

		}
	}


	private void DestroyThis ()
	{
			Destroy(this.gameObject);
	}

}
