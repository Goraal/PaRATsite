using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDLeftManager : MonoBehaviour {
    public bool refreshAction;
    public GameObject currentPawn;
    private Animator[] anim_Actions;
    private MovingPerso mv_p;
    private string mv_action;
    private Transform pawnFace;
    private GameMasterCode gmc;


    // Use this for initialization.
    void Start () {
        // Debug.Log("Avancer ICI : but supprimer les show action et les gérer ici. Une update pour toutes les actions");
        refreshAction = true;
        mv_p = currentPawn.GetComponent<MovingPerso>();
        pawnFace = this.transform.Find("pawnFace");
        gmc = GameObject.Find("GameMaster").GetComponent<GameMasterCode>();
        // Debug.Log("HUDLeft//Start/ gmc :" + gmc + " currentPawn:" + currentPawn);
        gmc.currentPawn = currentPawn;
    }
	
	// Update is called once per frame.
	void Update () {
        // Update only once
        if (refreshAction)
        {
            refreshAction = false;
            UpdateAction();
        }
        
    }


    void UpdateAction()
    {
        Animator anim_Action;
        anim_Actions = gameObject.GetComponentsInChildren<Animator>();

        for (int i = 0; i < anim_Actions.Length; i++)
        {
            anim_Action = anim_Actions[i];
           // Debug.Log("HUDLeftManager//UpdateAction Anim : " + anim_Action );


            // Update if the action no longer exist
            if (mv_p.l_action.Count <= i)
            {
                anim_Action.SetTrigger("tEMPTY");
            }
            else
            {
                mv_action = mv_p.l_action[i];

                // Update if the action is known
                if ((mv_action == "UP") || (mv_action == "DOWN") || (mv_action == "RIGHT") || (mv_action == "LEFT"))
                {
                    anim_Action.SetTrigger("tGo" + mv_action);
                }
                // Update if the action is unknown
                else
                {
                    anim_Action.SetTrigger("tEMPTY");
                }
            }
        }      
    }


    public void ChangeCurrentPawn(GameObject newPawn)
    {
        // Debug.Log("HUDLeft//ChangeCurrentPawn "+ newPawn);
        Debug.Log("HUDLeft A ameliorer : ChangeCurrentPawn dans GameMaster");
        gmc.currentPawn = newPawn;
        currentPawn = newPawn;
        mv_p = newPawn.GetComponent<MovingPerso>();
        refreshAction = true;
        pawnFace.GetComponent<UnityEngine.UI.Image>().sprite = mv_p.faceSprite;
    }

}
