using UnityEngine;
using System.Collections;

public class CHAR_FRONT_DETECT : MonoBehaviour {

    public GameObject detector;
    public GameObject holder;
    public float detectDistance = 10;
    public bool canMoveObject = false;
    public bool canPressObject = false;
    public Transform moveTarget;
    void Update()
    {
        DetectForwardObject();
    }
    void DetectForwardObject()
    {
        RaycastHit objectHit;
        Vector3 fwd = detector.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(detector.transform.position, fwd * detectDistance, Color.green);
        
        if (Physics.Raycast(detector.transform.position, fwd, out objectHit, detectDistance))
        {
            
            
            if(objectHit.collider.tag == "Movable")
            {   

                moveTarget = objectHit.transform;
                canMoveObject = true;
                /*
                Debug.Log(moveTarget.name);
                //pick up
                Debug.Log("this is movable");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log("Pick up");
                    moveTarget.parent = holder.transform;
                    moveTarget.transform.position = howlder.transform.position;

                }
                */

            }
            else if(objectHit.collider.tag == "Pressable")
            {
                //press
                Debug.Log("This is pressable");
            }
            
        }
        else
        {
            //Debug.Log("nothing");
            canMoveObject = false;
            canPressObject = false;
        }

    }
}
