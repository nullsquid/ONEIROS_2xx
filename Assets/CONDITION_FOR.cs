using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class CONDITION_FOR : MonoBehaviour {
    int iterations;
    bool isOn;
    float input = 0;
    float output = 0;

    //branches
    public List<GameObject> connectedNodes = new List<GameObject>();

    IEnumerator LoopForTimes(int loopsLeft) {
        while(loopsLeft >= 0) {
            //send message to connected nodes to activate
            loopsLeft--;
        }
        yield return null;
    }
}
