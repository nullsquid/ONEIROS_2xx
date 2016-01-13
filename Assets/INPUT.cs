using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class INPUT : MonoBehaviour {
    //private UnityAction inputListenerOn;
    //private UnityAction inputListenerOff;
    float value;
    public bool binValue = false;
    public bool isConnected = false;
    void Awake() {
        //inputListenerOn = new UnityAction(TurnInputOn);
        //inputListenerOff = new UnityAction(TurnInputOff);

    }
    void OnEnable() {
        EventManager.StartListening("binOn", TurnInputOn);
        EventManager.StartListening("binOff", TurnInputOff);

    }

    void OnDisable() {
        EventManager.StopListening("binOn", TurnInputOn);
        EventManager.StopListening("binOff", TurnInputOff);
       
    }

    
    void TurnInputOn() {
        if (binValue == false) {
            binValue = true;
            isConnected = true;
            
        }
        //gameObject.GetComponent<BoxCollider>().enabled = false;
        EventManager.TriggerEvent("outOn");
        Debug.Log("ON");
    }

    void TurnInputOff() {
        if (binValue == true) {
            binValue = false;
            isConnected = false;
            
        }
        EventManager.TriggerEvent("outOff");
        //gameObject.GetComponent<BoxCollider>().enabled = true;
    }

    void Update() {
        if(isConnected == true) {
            GetComponent<BoxCollider>().enabled = false;
                 
        }
        else if(isConnected == false) {
            GetComponent<BoxCollider>().enabled = true;
        }
    }
    
}
