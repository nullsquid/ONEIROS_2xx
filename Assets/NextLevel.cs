using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
    public EXITBLOCK exitBlock;
	// Use this for initialization
	void Start () {
        exitBlock = GetComponentInParent<EXITBLOCK>();
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider other) {
        if (exitBlock.exitIsOpened){
            if(other.tag == "Player") {
                Debug.Log("Level Complete");
            }
        }
	    //if(exitBlock.exitIsOpened)
	}
}
