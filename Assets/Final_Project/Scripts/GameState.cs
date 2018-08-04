﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GameState : NetworkBehaviour {
    //public ArrayList players = new ArrayList();

    public float[] players= new float[4];
    //[SyncVar]
    public  int maxPlayers = 4;
    [SyncVar]
    public int winner;

    private CustomNetworkDiscovery netScript;
    public GameObject netGameObj;


    bool p1set;
    bool p2set;


	// Use this for initialization
	void Start () {
        netScript = netGameObj.GetComponent<CustomNetworkDiscovery>();
        p1set = netScript.Player1Set();
        p2set = netScript.Player2Set();
	}
	
	// Update is called once per frame
	void Update () {
        if (p1set)
        {
            AddPlayer(0,0);
            //print(0);
            p1set = false;

        }
        if (p2set)
        {
            AddPlayer(1, 0);
            //print(0);
            p1set = false;
        }

	}

    public void AddPlayer(int index, float num) {
        players[index] = num;
        if (index == 0)
            print("Player 1 added to game");
        
        else if (index == 1)
            print("Player 2 added to game");
    }

    //public bool DoneCheckingPlayer1()
    //{
    //    if (netScript.Player1Set())
    //    {
    //        return false;
    //    }
    //    return true;
    //}
}
