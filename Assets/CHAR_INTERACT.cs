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
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log(KeyCode.Mouse0);
                detector.moveTarget.parent = detector.holder.transform;
                detector.moveTarget.transform.position = detector.holder.transform.position;
                isHoldingObject = true;


            }

        }
        else if (isHoldingObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //detector.moveTarget.transform.position = grid.NearestFaceG(transform.position, GridFramework.GridPlane.XZ);
                detector.moveTarget.parent = null;
                isHoldingObject = false;

                
            }
        }
    }
}
