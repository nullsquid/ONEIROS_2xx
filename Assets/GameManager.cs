using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {


	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R)) {
            Debug.Log("Reset");
            Application.LoadLevel(Application.loadedLevel);
        }
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.RightShift)) {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
	}
}
