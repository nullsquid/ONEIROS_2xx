using UnityEngine;
using System.Collections;

public class RenderLineToOtherIf : MonoBehaviour {
    LineRenderer line;
    public IFBLOCK ifblock;
    public GameObject target;
    public INPUT input;
    public Limiter limiter;
    public bool connected;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, target.transform.position);
        //input = GetComponentInChildren<INPUT>();
	}
	
	// Update is called once per frame
	void Update () {
        if(input.isConnected)
        {
            connected = true;
        }
        else if (input.isConnected == false)
        {
            connected = false;
        }
        if (connected == true) {
            if (ifblock.conditionsMet == false)
            {
                line.GetComponent<Renderer>().enabled = true;
                if (limiter.outPower == 0)
                {
                    line.SetWidth(0.0f, 0.0f);
                }
                else if (limiter.outPower == 1)
                {
                    line.SetWidth(0.1f, 0.1f);
                }
                else if (limiter.outPower == 2)
                {
                    line.SetWidth(0.2f, 0.2f);
                }
                else if (limiter.outPower == 3)
                {
                    line.SetWidth(0.3f, 0.3f);
                }
            }
            else if (ifblock.conditionsMet == true)
            {
                line.SetWidth(0.0f, 0.0f);
            }
        }
        else if(connected == false)
        {
            line.GetComponent<Renderer>().enabled = false;
        }
	}
}
