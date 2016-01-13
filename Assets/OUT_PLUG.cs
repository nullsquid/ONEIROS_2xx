using UnityEngine;
using System.Collections;

public class OUT_PLUG : MonoBehaviour {
    public Transform defaultParent;
    public bool pluggedIn;
    void Start() {
        defaultParent = transform.parent;
        if(transform.parent == null) {
            transform.parent = defaultParent;
        }

    }
    void Awake() {

    }
    void Update() {
        if(transform.parent == null) {
            transform.parent = defaultParent;
        }
        if(pluggedIn == true) {
            
        }
    }

    void OnTriggerEnter(Collider other) {
        if (pluggedIn == false) {
            
            if (other.tag == "IN PORT") {
                //EventManager.TriggerEvent("binOn");
                
                
                SendMessageUpwards("PutDown");
                pluggedIn = true;
                transform.position = other.transform.position;
                //SendMessageUpwards("DetachChildren");
                //transform.parent.GetComponent<CHAR_INTERACT>().isHoldingObject = false;
                //needs to tell the player to disable all of the state things where the player object thinks its holding an object when its really not
                

                transform.parent = defaultParent;
                
                Debug.Log("Connected");
                EventManager.TriggerEvent("binOn");
                //EventManager.TriggerEvent("hi");
            }
            
        }
        //StartCoroutine(CollisionCooldown());
    }
    void OnTriggerExit(Collider other) {
        if(pluggedIn == true) {
            if(other.tag == "IN PORT") {
                pluggedIn = false;
                //EventManager.TriggerEvent("binOff");
            }
        }
    }
    IEnumerator CollisionCooldown() {
        
        yield return new WaitForSeconds(1.0f);
    }
   
}
