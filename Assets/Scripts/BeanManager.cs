using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanManager : MonoBehaviour
{
    public float maxTime = 60f;
    public float time = 60f;
    public float timePerBean = 5f;
    public Transform[] spawnPoints;
    public GameObject[] beanObjects;
    public bool endless = false;
    public Wave[] waves;

    int wave = 0;
    int beanNumber;
    List<GameObject> beans;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        //Test if all the beans are ded
        bool allBeans = false;
        foreach(GameObject bean in beans){
            if (bean){
                allBeans = true;
            }
        }
        if (!allBeans){
            //If so, spawn a new wave
            if (endless){
                wave++;
                Spawn();
            }
            else{
                wave++;
                if (wave < waves.Length){
                    Spawn();
                }else{
                    Win();
                }
            }
        }
        time -= Time.deltaTime;
        if (time <= 0){
            //Code for death here
        }
    }

    void Spawn(){
        if (endless){
            beans = new List<GameObject>();
            for (int i = 0; i < wave+1; i++){
                Vector3 position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                GameObject beanObject = ChooseBeanType(new Wave());
                beans.Add(Instantiate(beanObject, position, transform.rotation));
            }
        }else{
            Wave genWave = waves[wave];
            beanNumber = genWave.beans+genWave.potatoes+genWave.watermelons+genWave.peanuts;
            beans = new List<GameObject>();
            for (int i = 0; i < beanNumber; i++){
                Vector3 position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
                GameObject beanObject = ChooseBeanType(genWave);
                beans.Add(Instantiate(beanObject, position, transform.rotation));
            }
        }
    }

    public void AddObject(GameObject obj){
        beans.Add(obj);
    }

    GameObject ChooseBeanType(Wave wave){
        if (endless){
            int beanType = Random.Range(0, 4);
            return beanObjects[beanType];
        }else{
            bool done = false;
            int beanType = 0;
            while (!done){
                beanType = Random.Range(0, 4);
                switch (beanType){
                    case 0:
                        if (wave.beans > 0){
                            done = true;
                            wave.beans--;
                        }
                        break;
                    case 1:
                        if (wave.potatoes> 0){
                            done = true;
                            wave.potatoes--;
                        }
                        break;
                    case 2:
                        if (wave.watermelons > 0){
                            done = true;
                            wave.watermelons--;
                        }
                        break;
                    case 3:
                        if (wave.peanuts > 0){
                            done = true;
                            wave.peanuts--;
                        }
                        break;
                }
            }
            return beanObjects[beanType];
        }
    }

    void Win(){
        Destroy(gameObject);
    }
}
