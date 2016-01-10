using UnityEngine;
using System.Collections;

public class CHAR_INTERACT : MonoBehaviour {

    CHAR_FRONT_DETECT detector;
    public bool isHoldingObject = false;
    public GFRectGrid grid;
	void Start()
    {
        detector = gameObject.GetComponent<CHAR_FRONT_DETECT>();

    }

    void Update()
    {
        if (detector.canMoveObject == true && isHoldingObject == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //detector.moveTarget.transform.position = detector
                PickUp();


            }

        }
        else if (isHoldingObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PutDown();
                
            }
        }
    }

    void PutDown() {
        detector.holder.transform.DetachChildren();
        isHoldingObject = false;
    }

    void PickUp() {
        detector.moveTarget.parent = detector.holder.transform;
        detector.moveTarget.transform.position = detector.holder.transform.position;
        isHoldingObject = true;
    }
}
