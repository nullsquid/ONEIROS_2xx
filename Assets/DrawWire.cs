using UnityEngine;
using System.Collections;

public class DrawWire : MonoBehaviour {
    LineRenderer wire;
    public GameObject plug;
	// Use this for initialization
	void Start () {
        wire = GetComponent<LineRenderer>();
        wire.SetPosition(0, transform.position); 
	}
	
	// Update is called once per frame
	void Update () {
        wire.SetPosition(1, plug.transform.position);
	}
}
