using UnityEngine;
using System.Collections;

public class FrontDetect : MonoBehaviour {

    public AI_MOVE_SIMPLE ai;

    void Start() {
        ai = GetComponentInParent<AI_MOVE_SIMPLE>();
    }

    void OnTriggerEnter(Collider other) {
        //Debug.Log("flip");
        //if (other.tag == "wall") {
        ai.flipped = !ai.flipped;
        //}
    }
}
