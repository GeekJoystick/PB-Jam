using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanManager : MonoBehaviour
{
    public int beanNumber;
    public GameObject beanObject;

    GameObject[] beans;
    GameObject potato;

    // Start is called before the first frame update
    void Start()
    {
        beans = new GameObject[beanNumber];
        for (int i = 0; i < beanNumber-1; i++){
            beans[i] = Instantiate(beanObject, transform.position, transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
