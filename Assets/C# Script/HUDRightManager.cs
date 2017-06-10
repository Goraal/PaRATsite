using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDRightManager : MonoBehaviour {
    private GameMasterCode gmc;
    

    // Use this for initialization
    void Start () {
        gmc = GameObject.Find("GameMaster").GetComponent<GameMasterCode>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddAction(string newAction)
    {
        gmc.currentPawn.GetComponent<MovingPerso>().AddAction(newAction);
    }

    public void DoingAllAction()
    {
        foreach(MovingPerso pawn in gmc.tabPawnCode)
        { 
            pawn.DoingAllAction();
        }
    }

    public void DoingOneAction()
    {
        foreach (MovingPerso pawn in gmc.tabPawnCode)
        {
            pawn.DoingOneAction();
        }
    }
}
