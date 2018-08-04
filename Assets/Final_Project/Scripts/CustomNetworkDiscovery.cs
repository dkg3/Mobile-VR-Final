﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkDiscovery : NetworkDiscovery {
    private bool _receivedBradcast = false;

    float playernum;
    bool playNumSet;


    public float playerNumber;

    public bool player1set;
    public bool player2set;

	private void Start()
	{
       // gsScript = GameObject.Find("GameState").GetComponent<GameState>();
        Initialize();
        //TODO
        // access Game State Script
	}

    public override void OnReceivedBroadcast(string fromAddress, string data)
    {
        if (!_receivedBradcast)
        {
            _receivedBradcast = true;
            base.OnReceivedBroadcast(fromAddress, data);
            Debug.Log("FromAddress: " + fromAddress + "  Data: " + data);
            string[] addressSplit  = fromAddress.Split(':');
            string[] dataSplit = data.Split(':');
            NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
            NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
            NetworkManager.singleton.StartClient();
        }
    }

    public void StartListeningBroadcast() 
    {
        StartAsClient();
        //playernum = (int)Random.Range(1f,3.9f);
        //  SetPlayerNumber(1);
        // playNumSet = true;
        player2set = true;
    }

    public void StartAsHost () 
    {
        NetworkManager.singleton.StartHost();
        StartAsServer();
      //  SetPlayerNumber(0);
        player1set = true;
       // playNumSet = true;
    }

    //public bool PlayerNumIsSet()
    //{
    //    return playNumSet;
    //}



    //public void SetPlayerNumber(float num){
    //    playernum = num;
    //}
    //public float GetPLayerNumber(){
    //    return playernum;
    //}

    public bool Player1Set()
    {
        return player1set;
    }
    public bool Player2Set()
    {
        return player2set;
    }
}















//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Networking;

//public class CustomNetworkDiscovery : NetworkDiscovery
//{
//    private bool _receivedBradcast = false;

//    float playernum;
//    bool playNumSet;

//    private void Start()
//    {
//        Initialize();
//        //TODO
//        // access Game State Script
//    }

//    public override void OnReceivedBroadcast(string fromAddress, string data)
//    {
//        if (!_receivedBradcast)
//        {
//            _receivedBradcast = true;
//            base.OnReceivedBroadcast(fromAddress, data);
//            Debug.Log("FromAddress: " + fromAddress + "  Data: " + data);
//            string[] addressSplit = fromAddress.Split(':');
//            string[] dataSplit = data.Split(':');
//            NetworkManager.singleton.networkAddress = addressSplit[addressSplit.Length - 1];
//            NetworkManager.singleton.networkPort = int.Parse(dataSplit[dataSplit.Length - 1]);
//            NetworkManager.singleton.StartClient();
//        }
//    }

//    public void StartListeningBroadcast()
//    {
//        StartAsClient();
//        playernum = (int)Random.Range(1f, 3.9f);
//        playNumSet = true;
//        // accessing the game state script, check if rand num exists

//    }

//    public void StartAsHost()
//    {
//        NetworkManager.singleton.StartHost();
//        StartAsServer();
//        SetPlayerNumber(0);
//        playNumSet = true;
//    }

//    public bool PlayerNumIsSet()
//    {
//        return playNumSet;
//    }
//    public void SetPlayerNumber(float num)
//    {
//        playernum = num;
//    }
//    public float GetPLayerNumber()
//    {
//        return playernum;
//    }
//}