using UnityEngine;
using System.Collections;

public class CAMERA_OVERHEAD : MonoBehaviour {

    public GameObject target;
    public float damping;

    Vector3 offset;
	// Use this for initialization
	void Start () {
        offset = transform.position - target.transform.position;
        Debug.Log(offset);
	}

    void LateUpdate()
    {
        Vector3 newPosition = target.transform.position + offset;
        Vector3 posision = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * damping);
        transform.position = posision;
    }
	
}
