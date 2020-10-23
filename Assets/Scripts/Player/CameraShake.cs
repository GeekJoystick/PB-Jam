using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    float instensity = 0f;
    float decrease = 0f;
    public void Shake(float inte, float dec){
        instensity = inte;
        decrease = dec;
    }

    void Update(){
        if (instensity > 0f){
            transform.localPosition = new Vector3(Random.Range(-instensity, instensity), Random.Range(-instensity, instensity), Random.Range(-instensity, instensity));
            instensity -= decrease;
            if (instensity <= 0f){
                instensity = 0f;
            }
        }else{
            transform.localPosition = new Vector3(0f, 0f, 0f);
        }
    }

}
