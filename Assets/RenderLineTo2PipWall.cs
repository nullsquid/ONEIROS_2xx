using UnityEngine;
using System.Collections;

public class RenderLineTo2PipWall : MonoBehaviour {
    LineRenderer line;
    public GameObject target;
    public IFBLOCK ifblock;
    public INPUT input;
    public Limiter limiter;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, target.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (input.isConnected)
        {
            if (ifblock.conditionsMet == true)
            {
                line.GetComponent<Renderer>().enabled = true;
            }
            else
            {
                line.GetComponent<Renderer>().enabled = false;
            }
        }
        else if(input.isConnected == false)
        {
            line.GetComponent<Renderer>().enabled = false;
        }
	}
}
