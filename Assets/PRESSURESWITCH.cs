using UnityEngine;
using System.Collections;

public class PRESSURESWITCH : MonoBehaviour {
    public bool isPressed;
    public bool isOutputting;
	void OnTriggerStay(Collider other) {
        if (other.tag == "Player" || other.tag == "Actor") {
            if (isPressed == false) {
                isPressed = true;
                isOutputting = true;
                StartCoroutine(Compress());

            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Actor") {
            StartCoroutine(Compress());
            EventManager.TriggerEvent("exitOpen");
        }
        if(other.tag == "Player")
        {
            EventManager.TriggerEvent("startFill");
        }
    }
    void OnTriggerExit(Collider other) {
        if (other.tag == "Player") {
            if (isPressed == true) {
                isPressed = false;
                isOutputting = false;
                
                StartCoroutine(Depress());
                
            }
            //Debug.Log("hey");
            //StopAllCoroutines();
            EventManager.TriggerEvent("stopFill");
            EventManager.TriggerEvent("startCountdown");
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
