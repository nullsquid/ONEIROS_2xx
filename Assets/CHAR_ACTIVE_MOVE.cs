using UnityEngine;
using System.Collections;

public class CHAR_ACTIVE_MOVE : MonoBehaviour {

    public float speed;
    private float vertAxis;
    private float horAxis;
    private CharacterController controller;
    
    

    void Update()
    {
        if(Input.GetAxis("Vertical") > 0)
        {
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
            
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0);
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            transform.eulerAngles = new Vector3(0, 270, 0);
            transform.Translate(new Vector3(0, 0, speed) * Time.deltaTime);
        }
    }

}
