using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TimeDisplayController : MonoBehaviour {
    public List<Transform> children = new List<Transform>();
    public List<Transform> revChildren = new List<Transform>();
    public Transform curChild;
    public Transform newCurChild;
    public bool countDownIsComplete = false;
    public bool moduleIsFull = false;
    public int waitSeconds;
    public Color filledColor;
    public Color unfilledColor;
    public OUTPUT_TRUE output;
    public PRESSURESWITCH pSwitch;
    public INPUT input;
    public OUT_PLUG plug;
    public OUTPUT output_check;
	// Use this for initialization
	void Start () {
	    foreach(Transform child in gameObject.GetComponent<Transform>())
        {
            //children.Add(child);
            child.GetComponent<Renderer>().enabled = false;
        }
        //curChild = children[0];
        //StartCoroutine(StartFilling(waitSeconds));
        
        
	}
    
    void OnEnable()
    {
        EventManager.StartListening("stopFill", StopFill);
        EventManager.StartListening("startCountdown", TriggerCountdown);
        EventManager.StartListening("startFill", TriggerFill);
    }

    void OnDisable()
    {
        EventManager.StopListening("stopFill", StopFill);
        EventManager.StopListening("startCountdown", TriggerCountdown);
        EventManager.StopListening("startFill", TriggerFill);
    }
	// Update is called once per frame
	void TriggerCountdown()
    {
        //if (output_check.isOn)
       //{
            
            Debug.Log("working");
            StopCoroutine("TriggerFill");
            StartCoroutine(CountDown(waitSeconds));
        //}
    }

    void ChangeColor(Transform currentChild)
    {
        Debug.Log("color change");
        currentChild.GetComponent<Renderer>().material.color = Color.Lerp(filledColor, unfilledColor, 10f);
    }
    void TriggerFill()
    {
        if (output_check.isOn)
        {
            //StopCoroutine("TriggerCountdown");
            StartCoroutine(StartFilling(waitSeconds));
        }
    }

    void StopFill()
    {
        StopCoroutine("TriggerFill");
    }
    
    IEnumerator StartFilling(int waitTime)
    {
        if (output_check.isOn)
        {
            output.isOn = true;
        }
            int i = 0;
            while (i < revChildren.Count)
            {
                yield return new WaitForSeconds(waitTime);
                curChild = revChildren[i];
                
                if(pSwitch.isOutputting == false)
            {
                yield break;
            }
                curChild.GetComponent<Renderer>().enabled = true;
                i += 1;

                
            
            curChild = null;
            //StartCoroutine(CountDown(waitSeconds));
            //moduleIsFull = true;
            }
         
        
    }
    IEnumerator CountDown(int waitTime)
    {
        countDownIsComplete = false;
        //while (countDownIsComplete == false) {
            //while (input.binValue == false)
            //{
                
                Debug.Log("bin value");
                for (int i = 0; i < children.Count; i++)
                {
                    curChild = children[i];
                    yield return new WaitForSeconds(waitTime);
                    //if()
                //ChangeColor(curChild);
                //curChild.GetComponent<GameObject>().SetActive(false);
                curChild.GetComponent<MeshRenderer>().enabled = false;
            //Debug.Log(curChild);
            if (output_check.isOn)
            {
                output.isOn = true;
            }
                }
        output.isOn = false;
            //}
            //countDownIsComplete = true;
        //}
    }
}
