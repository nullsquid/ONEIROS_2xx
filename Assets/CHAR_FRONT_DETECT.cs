using UnityEngine;
using System.Collections;

public class CHAR_FRONT_DETECT : MonoBehaviour {

    public GameObject detector;
    public float detectDistance = 10;

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
                //pick up
                Debug.Log("this is movable");
            }
            else if(objectHit.collider.tag == "Pressable")
            {
                //press
                Debug.Log("This is pressable");
            }
                
        }

    }
}
