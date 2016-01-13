using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CONDITION_IF : MonoBehaviour {

    bool isOn;
    float input = 0;
    float output = 0;
    bool binInput = false;
    bool binOutput = false;
    bool isBinary;
    bool isGradient;
    INPUT inPort;
    OUTPUT_TRUE outPortTrue;
    OUTPUT_FALSE outPortFalse;
    //branches
    public List<GameObject> connectedNodes = new List<GameObject>();
    void Start() {
        inPort = GetComponentInChildren<INPUT>();
        outPortTrue = GetComponentInChildren<OUTPUT_TRUE>();//GameObject.Find("OUT_TRUE");
        outPortFalse = GetComponentInChildren<OUTPUT_FALSE>();//GameObject.Find("OUT_FALSE");
    }
    void Update() {
        if (isBinary) {
            //if(inPort.)
            if(inPort.binValue == true) {
                binOutput = true;
                //outPortTrue.outputValue
            }
        }
    }
    
    public bool TurnBinConnectionsOn(bool input) {
        return false;
    }
    public bool TurnConnectionsOn(float input, float threshold, string condition) {
        switch (condition) {
        case "GT":
                 if (input > threshold) {
                     return true;
                 }
                else {
                    return false;
                }
        case "GTE":
                if(input >= threshold){
                    return true;
                }
                else {
                    return false;
                }
        case "LT":
                if(input < threshold) {
                    return true;
                }
                else {
                    return false;
                }
        case "LTE":
                if(input <= threshold) {
                    return true;

                }
                else {
                    return false;
                }
        case "E":
                if (input == threshold) {
                    return true;
                }
                else {
                    return false;
                }



        }
        return false;
    }
}
