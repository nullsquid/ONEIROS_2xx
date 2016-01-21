using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Limiter : MonoBehaviour {
    public List<GameObject> pips = new List<GameObject>();

    public int inPower = 3;
    public int limiting = 0;
    public int outPower;

    void OnEnable() {
        EventManager.StartListening("increaseCutoff", IncreaseCutoff);
    }
    void OnDisable() {
        EventManager.StopListening("increaseCutoff", IncreaseCutoff);
    }
    void Update() {
        
    }

    void CalculateOutPower(int input) {
        outPower = input - limiting;
    }

    void IncreaseCutoff() {
        limiting += 1;
        if(limiting > inPower) {
            limiting = 0;
        }
    }
}
