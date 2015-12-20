using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PORT_CONNECTOR : MonoBehaviour {
    public GameObject startRoute;
    public GameObject endRoute;
    private LineRenderer line;
    void Start()
    {
        line = new LineRenderer();
    }
	
}
