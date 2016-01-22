using UnityEngine;
using System.Collections;

public class IFBLOCK : MonoBehaviour {
    public bool conditionsMet;
    public int numOfPips;
    public Limiter limiter;
    INPUT input;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (numOfPips == 2)
        {
            if(limiter.outPower == 2)
            {
                conditionsMet = true;
            }
            else
            {
                conditionsMet = false;
            }
        }
        else if (numOfPips == 1)
        {
            if(limiter.outPower == 1)
            {
                conditionsMet = true;
            }
            else
            {
                conditionsMet = false;
            }
        }
	}
}
