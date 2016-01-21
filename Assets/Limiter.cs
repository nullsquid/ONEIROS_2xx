using UnityEngine;
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
            case 0:
                CheckPips(limiting);
                break;
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

    //HACK
    //Not scalable
    void CheckPips(int threshold)
    {
        if (threshold == 0) {
            for(int i = 0; i < pips.Count; i++) {
                pips[i].GetComponent<Renderer>().enabled = true;
            }
        }
        else if(threshold == 1) {
            for(int i = 0; i < pips.Count; i++) {
                if(i == 2) {
                    pips[i].GetComponent<Renderer>().enabled = false;
                }
            }
        }
        else if (threshold == 2) {
            for (int i = 0; i < pips.Count; i++) {
                if (i == 1) {
                    pips[i].GetComponent<Renderer>().enabled = false;
                }
            }
        }
        else if (threshold == 3) {
            for (int i = 0; i < pips.Count; i++) {
                if (i == 0) {
                    pips[i].GetComponent<Renderer>().enabled = false;
                }
            }
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
