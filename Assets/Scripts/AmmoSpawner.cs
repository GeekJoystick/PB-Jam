using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    public GameObject ammoPackPrefab;
    public float ammoRespawnTime;

    float ammoRespawnTimer;
    
    GameObject ammoPack;


    void Start(){
        //ammoPack = Instantiate(ammoPackPrefab, transform.position, transform.rotation);
    }

    void Update(){
        if (!ammoPack && ammoRespawnTimer <= 0f){
            ammoRespawnTimer = ammoRespawnTime;
        }
        if (ammoRespawnTimer > 0f){
            ammoRespawnTimer -= Time.deltaTime;
            if (ammoRespawnTimer <= 0f){
                ammoPack = Instantiate(ammoPackPrefab, transform.position, transform.rotation);
            }
        }
    }
}
