using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeanManager : MonoBehaviour
{
    public int nextLevel;
    public float maxTime = 60f;
    public float time = 60f;
    public float timePerBean = 5f;
    public int score = 0;
    public Transform[] spawnPoints;
    public GameObject[] beanObjects;
    public bool endless = false;
    public Wave[] waves;

    int wave;
    int beanNumber;
    List<GameObject> beans;


	//Sound
	public AudioSource RegularMusic;


    // Start is called before the first frame update
    void Start()
    {
        wave = -1;
        beans = new List<GameObject>();
        beans.Add(null);


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
                NewWave();
            }
            else{
                wave++;
                if (wave < waves.Length){
                    NewWave();
                }else{
                    Win();
                }
            }
        }
        time -= Time.deltaTime;

		if (time >= 31 && !RegularMusic.isPlaying)
		{
			RegularMusic.Play();
		}

		if (time <= 30)
		{
			RegularMusic.pitch = 1.1f;
		}
		if (time <= 0){
            Lose();
        }
    }

    void NewWave(){
        Health health = GameObject.Find("Player").GetComponent<Health>();
        WaveNumber wn = GameObject.Find("Wave Number").GetComponent<WaveNumber>();
        health.Regen();
        wn.ShowWave(wave+1);
        beans[0] = gameObject;
        Invoke("Spawn", 2f);
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
                Vector3 position = spawnPoints[Random.Range(0, spawnPoints.Length)].position+new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
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
        SceneManager.LoadScene(nextLevel);
        Destroy(gameObject);
    }

    void Lose(){
        SceneManager.LoadScene(3);
        Destroy(gameObject);
    }
}
