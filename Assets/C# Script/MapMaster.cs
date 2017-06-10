using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMaster : MonoBehaviour {
    public int height;
    public int width;
    public float floor_size;
    public Tiles[,] map;
    
    public class Tiles
    {
        public int floor=0;
        public int rightWall=0;
        public int downWall=0;

        
        public Tiles()
        {
            floor  = 0;
            rightWall = 0;
            downWall = 0;
        }
    }

    // Use this for initialization
    void Start () {
        double evenTile;
        map = new Tiles[width, height];
        
        //Avec des FOR ?
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                map[x, y] = new Tiles();
                evenTile = (x + y) / 2.0;
                if (System.Math.Truncate(evenTile) == evenTile)
                {
                    // Debug.Log("evenTile : " + evenTile + " " + System.Math.Truncate(evenTile));
                    map[x, y].floor = 1;
                }
            }
        }
        
        map[4, 0].rightWall = 1;
        map[4, 1].rightWall = 1;
        map[4, 2].rightWall = 1;
        map[4, 4].rightWall = 1;
        map[4, 5].rightWall = 1;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Vector3 pos;
                    //Floor
                   // Gizmos.color = (map[x, y].floor == 1) ? Color.black : Color.white;
                    // pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, 10);
                    // Gizmos.DrawCube(pos, Vector3.one);
                    //Wall
                    Gizmos.color = Color.red;
                    if (map[x, y].rightWall == 1)
                    {
                        Vector3 wallR = new Vector3(.2f, 1, .1f);
                        pos = new Vector3(-width / 2 + x + 1, -height / 2 + y + .5f, 8);
                        Gizmos.DrawCube(pos, wallR);
                    }

                    if (map[x, y].downWall == 1)
                    {
                        Vector3 wallD = new Vector3(1, .2f, .1f);
                        pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + 1, 8);
                        Gizmos.DrawCube(pos, wallD);
                    }
                }
            }
        }
    }

    public bool IsMovingToWall(int _posX, int _posY, string _sAction)
    {
        switch (_sAction)
        {
            case "UP":
                if (_posY == height - 1) return (true);
                if (map[_posX, _posY + 1].downWall == 1) return (true);
                return (false);
           case "LEFT":
                if (_posX == 0) return (true);
                if (map[_posX - 1, _posY].rightWall == 1) return (true);
                return (false);
            case "DOWN":
                if (_posY == 0) return (true);
                if (map[_posX, _posY].downWall == 1) return (true);
                return (false);
            case "RIGHT":
                if (_posX == width) return (true);
                if (map[_posX, _posY].rightWall == 1) return (true);
                return (false);
            default :
                return (false);
        }
    }
}
