using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    TextMeshProUGUI text;
    BeanManager beanManager;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        beanManager = GameObject.Find("Bean Spawner").GetComponent<BeanManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = beanManager.score.ToString();
    }
}
