using UnityEngine;
using System.Collections;

public class WaitToPlug : MonoBehaviour {

    LineRenderer line;
    public GameObject plug;
    public OUTPUT_TRUE out_check;
    void Start()
    {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.GetComponent<Renderer>().enabled = false;
    }

    void Update()
    {
        line.SetPosition(1, plug.transform.position);
        if(out_check.isOn == true)
        {
            line.GetComponent<Renderer>().enabled = true;
        }
        else if(out_check.isOn == false)
        {
            line.GetComponent<Renderer>().enabled = false;
        }
    }
}
