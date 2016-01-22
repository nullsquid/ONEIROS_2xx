using UnityEngine;
using System.Collections;

public class ExitLevel : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
        if (other.tag == "Player") {
            if (GetComponentInParent<EXITBLOCK>().exitIsOpened == true) {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }
    }
}
