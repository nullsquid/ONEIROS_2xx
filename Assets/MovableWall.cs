using UnityEngine;
using System.Collections;

public class MovableWall : MonoBehaviour {
    Vector3 startPos;
    public float speed;
    float startTime;

	// Use this for initialization
	void Start () {
        startTime = Time.time;
        startPos = transform.position;
        
	}
	
	// Update is called once per frame
	void Update () {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / 2.0f;
        //MoveWallUp();
	}

    public void MoveWallDown() {
        transform.position = Vector3.Lerp(startPos, new Vector3(startPos.x, startPos.y, startPos.z), 2.0f);
    }

    public void MoveWallUp() {
        transform.position = Vector3.Lerp(startPos, new Vector3(startPos.x, startPos.y + 1, startPos.z), 2.0f);
    }
}
