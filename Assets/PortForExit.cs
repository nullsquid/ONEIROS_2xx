using UnityEngine;
using System.Collections;

public class PortForExit : MonoBehaviour {
    public InputToExit input;
    public OUTPUT_TRUE output;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(input.conditionsMet == true) {
            if(output.isOn == true) {
                EventManager.TriggerEvent("exitOpen");
            }
            else if (output.isOn) {
                EventManager.TriggerEvent("exitClose");
            }
        }
        else if (input.conditionsMet == false) {
            EventManager.TriggerEvent("exitClose");
        }
	}
}
