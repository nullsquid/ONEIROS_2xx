using UnityEngine;
using System.Collections;

public class AI_MOVE_SIMPLE : MonoBehaviour {
    public float speed;
    public bool flipped = true;
    
	// Use this for initialization
	void Start() {
        flipped = true;
    }
    void OnEnable() {
        EventManager.StartListening("flip", TurnAround);
    }

    void OnDisable() {
        EventManager.StopListening("flip", TurnAround);
    }

    // Update is called once per frame
    void Update () {
        Move();
	}
    void Move() {
        if (flipped == true) {
            MoveForward();
        }
        else if (flipped == false) {
            MoveBackward();
        }
    }
    void MoveForward() {
        transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }
    void MoveBackward() {
        transform.Translate(new Vector3(-speed, 0, 0) * Time.deltaTime);
    }

    IEnumerator TurnSequence() {
        if (flipped == false) {
            transform.Translate(Vector3.zero * Time.deltaTime);
            gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
            yield return new WaitForSeconds(.5f);
            Debug.Log("flip");
            flipped = true;
            yield break;
        }
        else if (flipped == true) {
            /*
            transform.Translate(Vector3.zero * Time.deltaTime);
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            yield return new WaitForSeconds(.5f);
            Debug.Log("flop");
            flipped = false;
            yield break;
            */
        }
    }
    public void TurnAround() {
        Debug.Log("you there?");
        if(flipped == true) {
            MoveForward();
        }
        else if (flipped == false) {
            MoveBackward();
        }
        //StartCoroutine(TurnSequence());
        
    }
    
}
