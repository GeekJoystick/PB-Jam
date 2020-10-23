using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoints : MonoBehaviour
{
    public Image Heart1, Heart2, Heart3;
    public Sprite full, empty;

    Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(health.hitPoints){
        case 3:
            Heart1.sprite = Heart2.sprite = Heart3.sprite = full;
            break;
        case 2:
            Heart1.sprite = Heart2.sprite = full;
            Heart3.sprite = empty;
            break;
        case 1:
            Heart1.sprite = full;
            Heart2.sprite = Heart3.sprite = empty;
            break;
        case 0:
            Heart1.sprite = Heart2.sprite = Heart3.sprite = empty;
            break;
        }
    }
}
