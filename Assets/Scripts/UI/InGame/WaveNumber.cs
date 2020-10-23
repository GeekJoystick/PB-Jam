using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveNumber : MonoBehaviour
{
    public float maxTime;
    int phase;
    float alpha;
    float timer;
    string text;
    TextMeshProUGUI label;

    void Start(){
        label = GetComponent<TextMeshProUGUI>();
    }

    public void ShowWave(int wave){
        label.text = "Wave "+wave.ToString();
        alpha = 0f;
        timer = 0f;
        phase = 0;
    }

    void Update(){
        switch(phase){
        case 0:
            alpha += Time.deltaTime;
            if (alpha >= 1f){
                alpha = 1f;
                phase++;
            }
            break;
        case 1:
            timer += Time.deltaTime;
            if (timer >= maxTime){
                timer = 0f;
                phase++;
            }
            break;
        case 2:
            alpha -= Time.deltaTime;
            if (alpha <= 0f){
                alpha = 0f;
                phase++;
            }
            break;
        }
        label.color = new Color(label.color.r, label.color.g, label.color.b, alpha);
    }
}
