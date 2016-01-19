using UnityEngine;
using System.Collections;

public class WAIT : MonoBehaviour {
    INPUT input;
    OUTPUT_TRUE output;
	// Use this for initialization
	void Start () {
        input = GetComponentInChildren<INPUT>();
        output = GetComponentInChildren<OUTPUT_TRUE>();
	}
	
	

    IEnumerator Wait(int timeToWait) {
        //if(input)
        yield return new WaitForSeconds(timeToWait);
    }
}
