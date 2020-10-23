using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    float maxDelay = 5f;
    float delay;

    void Start(){
        delay = maxDelay;
    }

    void Update(){
        delay -= Time.deltaTime;
        transform.localScale = new Vector3(delay/maxDelay, delay/maxDelay, delay/maxDelay);
        if (delay <= 0f){
            Destroy(gameObject);
        }
    }
}