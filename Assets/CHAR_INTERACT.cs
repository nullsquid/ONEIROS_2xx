using UnityEngine;
using System.Collections;

public class CHAR_INTERACT : MonoBehaviour {

    CHAR_FRONT_DETECT detector;
    bool isHoldingObject = false;
	void Start()
    {
        detector = gameObject.GetComponent<CHAR_FRONT_DETECT>();

    }

    void Update()
    {
        if(detector.canMoveObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Pick up");
                detector.moveTarget.parent = detector.holder.transform;
                detector.moveTarget.transform.position = detector.holder.transform.position;

            }
        }
    }
}
