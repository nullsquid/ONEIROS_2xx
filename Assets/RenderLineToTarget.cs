using UnityEngine;
using System.Collections;

public class RenderLineToTarget : MonoBehaviour {

    public LineRenderer line;
    public OUTPUT_TRUE output;
    public GameObject target;
    void Start() {
        line = GetComponent<LineRenderer>();
        output = GetComponent<OUTPUT_TRUE>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, target.transform.position);
        line.SetWidth(0.0f, 0.0f);
    }

    void Update() {
        if(output.isOn == true) {
            line.SetWidth(0.1f, 0.1f);
            EventManager.TriggerEvent("exitOpen");
        }
        else if (output.isOn == false) {
            line.SetWidth(0.0f, 0.0f);
            EventManager.TriggerEvent("exitClose");
        }
    }

}
