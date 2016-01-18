using UnityEngine;
using System.Collections;

public class OUTPUT : MonoBehaviour {
    LineRenderer line;
    Vector3 exitPosition;
    GameObject exit;
    public Material onMaterial;
    public bool hasFixedOutput;
    public bool outputsToExit;
    public bool isOn;
	// Use this for initialization
	void Start () {
        //HACK//
        line = GetComponentInChildren<LineRenderer>();
        if (hasFixedOutput == true) {

            if (outputsToExit == true) {
                exit = GameObject.Find("Exit");
                

                line.SetPosition(1, new Vector3(exit.transform.position.x, 1, exit.transform.position.z));
            }
            
        }
	}
    void OnEnable() {
        EventManager.StartListening("outOn", OutputOn);
        EventManager.StartListening("outOff", OutputOff);
    }
    void OnDisable() {
        EventManager.StopListening("outOn", OutputOn);
        EventManager.StopListening("outOff", OutputOff);
    }
	
	// Update is called once per frame
	void Update () {
        if (isOn == true) {
            line.material = line.materials[1];
        }
        else  {
            line.material = line.materials[0];
        }
        if (outputsToExit) {
            if (isOn) {
                EventManager.TriggerEvent("exitOpen");
            }
            else {
                EventManager.TriggerEvent("exitClose");
            }
        }
    }
    void OutputOn() {
        isOn = true;
    }

    void OutputOff() {
        isOn = false;
    }

    
}
