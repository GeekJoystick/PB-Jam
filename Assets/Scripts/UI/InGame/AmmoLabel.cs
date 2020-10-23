using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoLabel : MonoBehaviour
{
    TextMeshProUGUI text;
    PlayerMovement pm;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        pm = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = pm.ammo.ToString()+"/10";
    }
}
