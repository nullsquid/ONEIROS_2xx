using UnityEngine;
using System.Collections;

public class EXITBLOCK : MonoBehaviour {

    public bool exitIsOpened = false;
    public GameObject exitGlow;
    void OnEnable() {
        EventManager.StartListening("exitOpen", OpenExit);
        EventManager.StartListening("exitClose", CloseExit);
    }
    void OnDisable() {
        EventManager.StopListening("exitOpen", OpenExit);
        EventManager.StopListening("exitClose", CloseExit);
    }
    void Update() {
        //if()
        if(exitIsOpened == false) {
            exitGlow.SetActive(false);
        }
        else if(exitIsOpened == true) {
            exitGlow.SetActive(true);
        }
    }

    void OpenExit() {
        exitIsOpened = true;
    }
    void CloseExit() {
        exitIsOpened = false;
    }
}
