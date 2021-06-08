using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class NetworkController : MonoBehaviourPunCallbacks
{
	[SerializeField]
	private Text feedbackText;

	bool isConnecting;

	[SerializeField]
	string createRoomName;
	[SerializeField]
	string joinRoomName;

	[SerializeField]
	private TMP_InputField inputCreateRoomName;
	[SerializeField]
	private TMP_InputField inputJoinRoomName;

	bool isConnected;

	public void Connect()
	{
		feedbackText.text = "";

		LogFeedback("Connecting...");
		PhotonNetwork.ConnectUsingSettings();
		PhotonNetwork.GameVersion = "1";
	}

	public override void OnConnectedToMaster()
	{
		isConnected = true;
		LogFeedback("Connected");
		PhotonNetwork.JoinLobby(TypedLobby.Default);
	}

    public override void OnJoinedLobby()
    {
		LogFeedback("Loading...");
	}

    public void CreateRoom()
    {
		if (isConnected)
        {
			LogFeedback("try to create Room...");

			createRoomName = inputCreateRoomName.text;

			if (string.IsNullOrWhiteSpace(createRoomName))
			{
				LogFeedback("invalid room name");
			}
			else
			{
				Debug.Log(inputCreateRoomName.text);
				RoomOptions options = new RoomOptions();
				options.MaxPlayers = 2;
				PhotonNetwork.CreateRoom(createRoomName, options, TypedLobby.Default);
			}
		}
        else
        {
			LogFeedback("You're not yet connected");
        }	
	}

    public void Join()
    {
        if (isConnected)
        {
			LogFeedback("try to join Room...");

			joinRoomName = inputJoinRoomName.text;

			if (string.IsNullOrWhiteSpace(joinRoomName))
			{
				LogFeedback("invalid room name");
			}
			else
			{
				Debug.Log(inputJoinRoomName.text);
				PhotonNetwork.JoinRoom(joinRoomName);
			}
		}
    }

    public override void OnJoinedRoom()
	{
		LogFeedback("<Color=Green>OnJoinedRoom</Color> with " + PhotonNetwork.CurrentRoom.PlayerCount + " Player(s)");
		LogFeedback("RoomName: " + PhotonNetwork.CurrentRoom.Name);

		if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
		{
			LogFeedback("Wait for the other player :)");
		}
		if( PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            PhotonNetwork.LoadLevel("SampleScene");
			//PhotonNetwork.AutomaticallySyncScene = true;
		}
    }

    void LogFeedback(string message)
	{
		if (feedbackText == null)
		{
			return;
		}

		feedbackText.text += System.Environment.NewLine + message;
	}

}
