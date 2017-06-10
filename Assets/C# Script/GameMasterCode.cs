using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterCode : MonoBehaviour {
    public float taille_case = 1.5F;
    public GameObject currentPawn;
    public MovingPerso[] tabPawnCode;
    public MapMaster mapScript;
    public HUDLeftManager HUDLeft;

    // Use this for initialization
    void Start () {
        tabPawnCode = this.GetComponentsInChildren<MovingPerso>();
        mapScript = GameObject.Find("MapMaster").GetComponent<MapMaster>();

       // mapScript = GameObject.Find("MapMaster").GetComponent<MapMaster>();
        Debug.Log("ICI");
    }
	
	// Update is called once per frame
	void Update () {
		
	}


}
