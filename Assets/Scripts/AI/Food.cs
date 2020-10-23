using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Food : MonoBehaviour
{
    public GameObject ragdoll;
    public void Die(){
        Instantiate(ragdoll, transform.position, transform.rotation);
    }

}