using UnityEngine;
using System.Collections;

public class OUT_PLUG_FROMWAIT : MonoBehaviour {

    public LineRenderer line;
    public OUTPUT_TRUE output_check;
    public GameObject plug;
    void Start()
    {
        line = GetComponentInParent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.enabled = false;
    }

    void Update()
    {
        line.SetPosition(1, plug.transform.position);
        if(output_check.isOn == true)
        {
            line.enabled = true;
        }
        else if (output_check.isOn == false)
        {
            line.enabled = false;
        }
    }

    
}
