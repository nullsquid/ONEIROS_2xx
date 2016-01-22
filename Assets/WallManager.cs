using UnityEngine;
using System.Collections;

public class WallManager : MonoBehaviour {
    public MovableWall[] walls;
    public IFBLOCK[] ifblocks;
    public INPUT input;
    public Limiter limiter;
    // Use this for initialization


    // Update is called once per frame
    void Update()
    {
        if(input.isConnected == true)
        {
            TestWallMoveTrigger();
        }
        //if(ifblocks[0].)
        //TestWallMoveTrigger();
    }

    void TestWallMoveTrigger() {
        
        if(limiter.outPower == 2) {
            for (int i = 0; i < walls.Length; i++) {
                if (i == 0) {
                    walls[i].GetComponent<MovableWall>().MoveWallUp();
                }
                else {
                    walls[i].GetComponent<MovableWall>().MoveWallDown();
                }
            }
        }
        else if(limiter.outPower == 1) {
            for (int i = 0; i < walls.Length; i++) {
                if (i == 1) {
                    walls[i].GetComponent<MovableWall>().MoveWallUp();
                }
                else {
                    walls[i].GetComponent<MovableWall>().MoveWallDown();
                }
            }
        }
        else {
            for(int i = 0; i < walls.Length; i++) {
                walls[i].GetComponent<MovableWall>().MoveWallDown();
            }
        }
    }

}
