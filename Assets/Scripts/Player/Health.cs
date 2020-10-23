using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int maxHitPoints = 3;
    public int hitPoints;
    public float maxInviTime = 0.5f;
    float inviTime;

    CameraShake cameraShake;
    
    void Start()
    {
        hitPoints = maxHitPoints;
        inviTime = 2f;
        cameraShake = GameObject.Find("Main Camera").GetComponent<CameraShake>();
    }

    void Update(){
        if (inviTime > 0){
            inviTime -= Time.deltaTime;
        }
    }

    public void Hurt(){
        if (inviTime <= 0f){
            hitPoints --;
            inviTime = maxInviTime;
            cameraShake.Shake(0.25f, 0.005f);
            if (hitPoints <= 0){
                SceneManager.LoadScene(3);
            }
        }
    }

    public void Regen(){
        hitPoints = maxHitPoints;
    }
}
