using UnityEngine;
using System.Collections;

public class OUT_PLUG_FROM_WAIT : MonoBehaviour {
    public OUTPUT output;
    public InputToExit input;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (output.isOn) {
            if (input.conditionsMet) {
                EventManager.TriggerEvent("exitOpen");
            }
            else if (input.conditionsMet) {
                EventManager.TriggerEvent("exitClosed");
            }
        }
	}
}
