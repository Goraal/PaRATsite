using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAction : MonoBehaviour {

    


    // Use this for initialization
    void Start () {

    }

    
    // Update is called once per frame
   /* void Update() {
       
        // Update only if the action exist and there is a new event in this action.
       if ((mv_p.l_bActionNew.Count > numAction) && (mv_p.l_bActionNew[numAction]))
        {
            UpdateAction();
        }
        
    }
    

    void UpdateAction()  {
        // Update only once
        mv_p.l_bActionNew[numAction] = false;
        Debug.Log("ShowAction//UpdateAction Action N°" + numAction);
        // Update if the action no longer exist
        if (mv_p.l_action.Count <= numAction)
        {
            anim_Action.SetTrigger("tEMPTY");
            mv_p.l_bActionNew.RemoveAt(numAction);
            return;
        }

        //Update if the action exist and is known
        mv_action = mv_p.l_action[numAction];
        if ((mv_action == "UP") || (mv_action == "DOWN") || (mv_action == "RIGHT") || (mv_action == "LEFT"))
        {
            anim_Action.SetTrigger("tGo" + mv_action);
        }

        //Update if the action exist and is unknown
        else
        {
            anim_Action.SetTrigger("tEMPTY");
        }
    }
    */

}