using UnityEngine;
using System.Collections;

public class RenderLineToExit : MonoBehaviour {
    public PRESSURESWITCH pSwitch;
    LineRenderer line;
    public GameObject exitPlug;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        pSwitch = GetComponentInParent<PRESSURESWITCH>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, exitPlug.transform.position);
        line.SetWidth(0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (pSwitch.isPressed)
        {
            line.SetWidth(0.1f, 0.1f);
        }
	}
}
