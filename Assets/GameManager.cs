using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reset");
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
