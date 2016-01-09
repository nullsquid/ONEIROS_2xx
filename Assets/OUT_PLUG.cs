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
    void Update() {
        if(transform.parent == null) {
            transform.parent = defaultParent;
        }
    }
}
