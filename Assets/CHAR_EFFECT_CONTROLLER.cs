using UnityEngine;
using System.Collections;

public class CHAR_EFFECT_CONTROLLER : MonoBehaviour {

    public GameObject auraGlow;
    public bool isEmittingParticles = false;

    CHAR_INTERACT interactor;

    void Start()
    {
        auraGlow.SetActive(false);
        interactor = gameObject.GetComponent<CHAR_INTERACT>();
    }
    void Update()
    {
        if(interactor.isHoldingObject == true)
        {
            auraGlow.SetActive(true);
        }
        else if (interactor.isHoldingObject == false)
        {
            auraGlow.SetActive(false);
        }
    }
    
}
