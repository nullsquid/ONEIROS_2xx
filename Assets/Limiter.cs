﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Limiter : MonoBehaviour {
    public List<GameObject> pips = new List<GameObject>();

    public int inPower = 3;
    public int limiting = 0;
    public int outPower;

    void Start()
    {
        CalculateOutPower(inPower);
        //CheckPips(limiting);
    }

    void OnEnable() {
        EventManager.StartListening("increaseCutoff", IncreaseCutoff);
    }
    void OnDisable() {
        EventManager.StopListening("increaseCutoff", IncreaseCutoff);
    }
    void Update() {
        switch (limiting)
        {
            /*case 0:
                CheckPips(limiting);
                break;*/
            case 1:
                CheckPips(limiting);
                break;
            case 2:
                CheckPips(limiting);
                break;
            case 3:
                CheckPips(limiting);
                break;
        }
    }
    void CheckPips(int threshold)
    {
        foreach(Transform child in gameObject.GetComponent<Transform>())
        {
            
        }

        for(int i = threshold; i > 0; i--)
        {
            pips[i].GetComponent<Renderer>().enabled = false;
        }

    }

    void CalculateOutPower(int input) {
        outPower = input - limiting;
    }

    void IncreaseCutoff() {
        limiting += 1;
        if(limiting > inPower) {
            limiting = 0;
        }
        CalculateOutPower(inPower);
    }
}
