using UnityEngine;
using System.Collections;

public class LimiterToPlug : MonoBehaviour {
    public LineRenderer line;
    public Limiter limiter;
    public GameObject plug;
	// Use this for initialization
	void Start () {
        line = GetComponentInParent<LineRenderer>();
        line.SetPosition(0, gameObject.transform.position);
        ChangeThickness();
	}
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(1, plug.transform.position);
        ChangeThickness();
	}
    //HACK
    //Not Scalable
    void ChangeThickness() {
        if(limiter.limiting == 0) {
            line.SetWidth(.3f, .3f);
        }
        else if(limiter.limiting == 1) {
            line.SetWidth(.2f, 0.2f);
        }
        else if (limiter.limiting == 2) {
            line.SetWidth(0.1f, 0.1f);
        }
        else if (limiter.limiting == 3) {
            line.SetWidth(0.0f, 0.0f);
        }
    }
}
