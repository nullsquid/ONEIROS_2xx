using UnityEngine;
using System.Collections;

public class InputToExit : MonoBehaviour {

    public bool conditionsMet;

    void OnEnable() {
        EventManager.StartListening("onToExit", TurnOn);
        EventManager.StartListening("offToExit", TurnOff);
    }
    void OnDisable() {
        EventManager.StopListening("onToExit", TurnOn);
        EventManager.StopListening("offToExit", TurnOff);
    }
    public void TurnOn() {
        conditionsMet = true;
    }
    public void TurnOff() {
        conditionsMet = false;
    }
}
