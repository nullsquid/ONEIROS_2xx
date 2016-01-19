using UnityEngine;
using System.Collections;

public class PRESSURESWITCH : MonoBehaviour {
    public bool isPressed;
    public bool isOutputting;
	void OnTriggerStay(Collider other) {
        if (other.tag == "Player") {
            if (isPressed == false) {
                isPressed = true;
                isOutputting = true;
                StartCoroutine(Compress());

            }
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            if (isPressed == true) {
                isPressed = false;
                isOutputting = false;
                StartCoroutine(Depress());
            }
        }
    }
    void Update() {
        //HACK
        if(isPressed == true) {
            isOutputting = true;
        }
        else if (isPressed == false) {
            isOutputting = false;
        }
    }
    IEnumerator Compress() {
        while(gameObject.transform.localScale.y >= .15f) {
            gameObject.transform.localScale -= new Vector3(0, .05f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator Depress() {
        while(gameObject.transform.localScale.y <= .5) {
            gameObject.transform.localScale += new Vector3(0, .05f, 0);
            yield return new WaitForEndOfFrame();
        }
    }
}
