using UnityEngine;
using System.Collections;
using GridFramework;
public class SNAP : MonoBehaviour {
    public GFRectGrid grid;
    public Transform cachedTransform;
  
    void Awake() {
        cachedTransform = transform;
        if (grid) {
            grid.AlignTransform(cachedTransform);
            cachedTransform.position = CalculatedOffset();
        }
    }

    Vector3 CalculatedOffset() {
        Vector3 gridPosition = grid.WorldToGrid(cachedTransform.position);
        gridPosition.y = 1f * transform.lossyScale.y; 
        return grid.GridToWorld(gridPosition);
    }
}
