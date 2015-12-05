using UnityEngine;
using System.Collections;

public class CHARACTER_MOVE : MonoBehaviour {

    public GFRectGrid grid;
    public int stepToCycle;

    Transform cachedTransform;

    void Awake()
    {
        cachedTransform = transform;
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
        Vector3 curPos;
        Vector3 newPos;
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector3.forward);
            
            FindNearestFace();
            

        }
    }

    Vector3 FindNearestFace()
    {
        Vector3 newPosition = grid.WorldToGrid(cachedTransform.position);
        
        Debug.Log("yes");
        newPosition = newPosition + Vector3.forward;
        

        for(int i = 0; i < 2; i++)
        {
            if(Mathf.Abs(newPosition[i]) > grid.size[i]){
                newPosition[i] -= Mathf.Sign(newPosition[i]) * 2.0f;
            }
        }
        return grid.GridToWorld(newPosition);
    }
}
