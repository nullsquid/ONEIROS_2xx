using UnityEngine;
using System.Collections;

public class RenderLineToPlug : MonoBehaviour {
    public OUT_PLUG plug;
    LineRenderer line;
    PRESSURESWITCH pSwitch;
	// Use this for initialization
	void Start () {
        plug = GetComponentInChildren<OUT_PLUG>();
        line = GetComponent<LineRenderer>();
        pSwitch = GetComponentInParent<PRESSURESWITCH>();
        line.SetPosition(0, gameObject.transform.position);
        line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        line.SetPosition(1, plug.transform.position);
        if(pSwitch.isOutputting == true) {
            line.enabled = true;
        }
        else if(pSwitch.isOutputting == false) {
            line.enabled = false;
        }
	}
}
