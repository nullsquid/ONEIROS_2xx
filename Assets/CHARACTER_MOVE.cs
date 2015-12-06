using UnityEngine;
using System.Collections;

public class CHARACTER_MOVE : MonoBehaviour {

    public GFRectGrid grid;
    public int stepToCycle;

    public Transform cachedTransform;

    void Awake()
    {
        //cachedTransform = transform;
        if (grid)
        {
            grid.AlignTransform(cachedTransform);
        }
    }

    void Update()
    {
        ButtonPressToMove();
    }
    void Move()
    {
        
    }

    void TapToMove()
    {

    }

    void ButtonPressToMove()
    {
        //Vector3 curPos;
        //Vector3 newPos;
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward);
            FindNearestFace();
        }
        
    }

    Vector3 FindNearestFace()
    {
        Vector3 newPosition = grid.WorldToGrid(cachedTransform.position);
        
        
        newPosition = newPosition + Vector3.forward;
        Debug.Log(newPosition);

        //for(int i = 0; i < 3; i++)
        //{
        // Debug.Log(i);
        if (Mathf.Abs(newPosition.z) > grid.size.z){
            //Debug.Log("too far");
            //transform.position.z -= Mathf.Sign(newPosition.z) * 2.0f;
            //transform.position.z =
            //transform.position.z = new Vector3(0, 0, grid.size.z);
            //setting the elements of a vector3 individually
            //look up grid constraints, broadly
                
            }
        if(Mathf.Abs(newPosition.x) > grid.size.x)
        {
            //stop it from going further

        }
        //}
        return grid.GridToWorld(newPosition);
    }
}
