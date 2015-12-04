using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CONDITION_IF : MonoBehaviour {

    bool isOn;
    float input = 0;
    float output = 0;

    //branches
    public List<GameObject> connectedNodes = new List<GameObject>();

    

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
