using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPerso : MonoBehaviour {
    public int initiative = 1;
    public int posPawnX;
    public int posPawnY;
    public List<string> l_action;
    public int i_maxAction;
    public bool isPlayer;
    public HUDLeftManager HUDLeft;
    public Sprite faceSprite;
    private List<string> l_validAction;
    private bool bAllAction;
    private float fDelayAction;
    private float fMaxDelayAction;
    private GameObject pawnManager;
    private GameMasterCode gmc;
    private float taille_case;


    // Use this for initialization
    void Start () {
        if (i_maxAction <= 0) i_maxAction = 1;
        if (i_maxAction >= 7) i_maxAction = 6;
        gmc = GameObject.Find("GameMaster").GetComponent<GameMasterCode>();
        bAllAction = false;
        fDelayAction = 0;
        fMaxDelayAction = 0.5f;
        taille_case = gmc.mapScript.floor_size;
    }


    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           // Debug.Log("Space key was pressed.");
            DoingOneAction();
        }
        if (Input.GetKeyDown("up"))
        {
            Debug.Log("Up key was pressed.");
        }

        if (bAllAction)
        {
            fDelayAction += Time.deltaTime;

            if (fDelayAction > fMaxDelayAction)
            {
                //Debug.Log("MovingPerso/Update/fDelayAction : " + fDelayAction + " et Max : " + fMaxDelayAction);
                fDelayAction = 0;
                DoingOneAction();
            }

        }
    }


    public void DoingOneAction(){

        int taille_l_action = l_action.Count;
        // En cas de demande d'action alors qu'on en a pas ...
        if (taille_l_action == 0)
        {
            bAllAction = false;
            return;
        }
        string s_action = l_action[0];
        // Debug.Log("MovingPerso// DoingOneAction1 " + taille_l_action);
        l_action.Remove(s_action);

        HUDLeft.refreshAction = true;

        // You cannot moving to wall
        if (gmc.mapScript.IsMovingToWall(posPawnX, posPawnY, s_action))
        {
            return;
        }
        switch (s_action)
        {
            // Debug.Log("Lenght<>0."+ s_action);
            case "UP":
                posPawnY++;
                transform.Translate(Vector3.up * taille_case);
                break;
            case "DOWN":
                posPawnY--;
                transform.Translate(Vector3.down * taille_case);
                break;
            case "LEFT":
                posPawnX--;
                transform.Translate(Vector3.left * taille_case);
                break;
            case "RIGHT":
                posPawnX++;
                transform.Translate(Vector3.right * taille_case);
                break;
        }
    }


    public void AddAction(string newAction)
    {
        if (l_action.Count == i_maxAction)
        {
            l_action.RemoveAt(i_maxAction-1);
        }
        l_action.Add(newAction);
        HUDLeft.refreshAction = true;
    }
    

    public void DoingAllAction()
    {
        // Debug.Log("MovingPerso\\ OnAct. : " + q_action);
        bAllAction = true;
        // First action directly done
        fDelayAction = fMaxDelayAction;
    }

    void OnMouseUpAsButton()
    {
        // Debug.Log("MovingPerso\\OnMouseUpAsButton");
        HUDLeft.ChangeCurrentPawn(this.gameObject);
    }
}

