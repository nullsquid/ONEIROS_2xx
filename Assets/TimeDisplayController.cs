using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TimeDisplayController : MonoBehaviour {
    public List<Transform> children = new List<Transform>();
    public Transform curChild;
    public bool countDownIsComplete = false;
    public int waitSeconds;
    public Color filledColor;
    public Color unfilledColor;
	// Use this for initialization
	void Start () {
	    /*foreach(Transform child in gameObject.GetComponent<Transform>())
        {
            children.Add(child);
        }*/
        //curChild = children[0];
        
        
        
	}

    void OnEnable()
    {
        EventManager.StartListening("startCountdown", TriggerCountdown);
    }

    void OnDisable()
    {
        EventManager.StopListening("startCountdown", TriggerCountdown);
    }
	// Update is called once per frame
	void TriggerCountdown()
    {
        StartCoroutine(CountDown(waitSeconds));

    }

    void ChangeColor(Transform currentChild)
    {
        Debug.Log("color change");
        currentChild.GetComponent<Renderer>().material.color = Color.Lerp(filledColor, unfilledColor, 10f);
    }

    

    IEnumerator CountDown(int waitTime)
    {
        while(countDownIsComplete == false)
        {
            for (int i = 0; i < children.Count; i++)
            {
                curChild = children[i];
                yield return new WaitForSeconds(waitTime);
                ChangeColor(curChild);
                curChild.GetComponent<Renderer>().enabled = false;

            }
            countDownIsComplete = true;
        }
    }
}
