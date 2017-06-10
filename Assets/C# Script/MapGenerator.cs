using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public int height = 40;
    public int width = 50;
    public float tileSize = 1.5f; //test for later.
    public int[,] map;
    public string seed;
    public bool useRandomSeed=false;
    public int minRoomSize = 2;
    // public int maxRoomSize = 10;
    // public int wallPercent = 50;
    public int sumPoint = 5;

    // Use this for initialization
    void Start()
    {
        // map = new int[width,lenght];
        CreateMap();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           CreateMap();
        }
    }

    void CreateMap()
    {
        map = new int[width, height];
        RandomFillMap();
        /*for (int i = 0; i < 5; i++){
            RoomMap();
        }*/
    }

    void RandomFillMap()
    {
        int roomSizeX;
        int roomSizeY;
        int currentX=0;
        int currentY=0;
        if (useRandomSeed) {
            seed = Time.time.ToString();
        }
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height -1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = 0; //(pseudoRandom.Next(0, 100) > wallPercent) ? 0 : 1;
                }
            }
        }
        for (int i = 0; i<5; i++)
        {
            
            roomSizeX = pseudoRandom.Next(minRoomSize, width - currentX - 1);
            roomSizeY = pseudoRandom.Next(minRoomSize, height - currentY - 1);
            map[roomSizeX, roomSizeY] = 1;

            /* for (int x = currentX; x < currentX + roomSizeX; x++)
             {
                 map[x, currentY] = 1;
             }
             Debug.Log("X=" + currentX + " dX=" + roomSizeX);
             currentX += roomSizeX;

            roomSizeY = pseudoRandom.Next(minRoomSize, height - currentY - 1);
             for (int y = currentY; y < currentY + roomSizeY; y++)
             {
                 map[currentX, y] = 1;
             }
             Debug.Log("Y=" + currentY + " dY=" + roomSizeY);
             currentY += roomSizeY;
             */

        }
    }

    void RoomMap()
    {
        int[,] newMap = new int[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    newMap[x, y] = 1;
                }
                else
                {
                    newMap[x, y] = (SumNearPoint( x,  y) >= sumPoint) ? 1 : 0;
                }
            }
        }
        
        //SumNearPoint(1, 1);
        map = newMap;
    }

    int SumNearPoint(int x, int y)
    {
        int count = 0;

        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                count += map[i, j];
               /* if (map[i, j] == 1)
                {
                    Debug.Log("i." + i + "j." + j + "=" + count);
                }*/
            }
        }
        //Debug.Log("x."+ x + "y."+y+"="+count);
        return (count);
    }

    void OnDrawGizmos()
    {
        if (map != null)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Gizmos.color = (map[x, y] == 1) ? Color.black : Color.white;
                    Vector3 pos = new Vector3(-width / 2 + x + .5f, -height / 2 + y + .5f, 10);
                    Gizmos.DrawCube(pos, Vector3.one);
                }
            }
        }
    }

}