using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;

public static class gameParametersContainer {
    public static gameParameters gameParam;
} 

//Should be declared identically to the gameParameters class in serverController.
public class gameParameters : MessageBase
{
    public int param;
    public string respawnTime;

    // private enum EHeightLevel{Crouch, Waist, Chest, Head, VerticalReach};
    // private float[] HeightCalibrationData = { 0, 0, 0, 0, 0 };
    // public float CrouchHeight { get { return HeightCalibrationData[(int)EHeightLevel.Crouch]; } private set { } }
    // public float WaistHeight { get { return HeightCalibrationData[(int)EHeightLevel.Waist]; } private set { } }
    // public float ChestHeight { get { return HeightCalibrationData[(int)EHeightLevel.Chest]; } private set { } }
    // public float HeadHeight { get { return HeightCalibrationData[(int)EHeightLevel.Head]; } private set { } }
    // public float VerticalReachHeight { get { return HeightCalibrationData[(int)EHeightLevel.VerticalReach]; } private set { } }

    // private enum EReachability { Close, ArmsLength, OutOfReach };
    // private float[] ReachabilityCalibrationData = { 0, 0, 0 };
    // public float CloseReachability { get { return ReachabilityCalibrationData[(int)EReachability.Close]; } private set { } }
    // public float ArmsLengthReachability { get { return ReachabilityCalibrationData[(int)EReachability.ArmsLength]; } private set { } }
    // public float OutOfReachReachability { get { return ReachabilityCalibrationData[(int)EReachability.OutOfReach]; } private set { } }
}

public class clientController : MonoBehaviour {

	NetworkClient myClient;
    public static short MSG_GAME_PARAMETERS_START = 1005;
	public static short MSG_GAME_PARAMETERS_UPDATE = 1006;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.S))
        {
            myClient = new NetworkClient();
            myClient.RegisterHandler(MsgType.Connect, OnConnected);     
            myClient.RegisterHandler(MSG_GAME_PARAMETERS_START, startGame);     
            myClient.RegisterHandler(MSG_GAME_PARAMETERS_UPDATE, updateToGame);     
            myClient.Connect("10.122.196.176", 4444);//127.0.0.1

        }
	}

	public void OnConnected(NetworkMessage netMsg)
    {
        Debug.Log("Connected to server.");
    }
    public void startGame(NetworkMessage netMsg)
    {
        Debug.Log("Received Start Message.");
    	gameParameters msg = netMsg.ReadMessage<gameParameters>();
        Debug.Log(msg.param);
        if(msg.param==1)
        {
        	SceneManager.LoadScene("Game");
            gameParametersContainer.gameParam = msg;
        }
    }
    public void updateToGame(NetworkMessage netMsg)
    {
        //TODO: Updating game parameters after the game has started.
    }


}
