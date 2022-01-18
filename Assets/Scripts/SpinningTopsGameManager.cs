using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class SpinningTopsGameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region UI Callback Methods
    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();


    }
    #endregion

    #region PHOTON Callback Methods
    public override void OnJoinRandomFailed(short returnCode, string message)
    {

        // base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);

        CreateAndJoinRoom();
    }

    public override void OnJoinedRoom()
    {
        // base.OnJoinedRoom();

        Debug.Log(PhotonNetwork.NickName + " joined to " + PhotonNetwork.CurrentRoom.Name);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined to " + 
            PhotonNetwork.CurrentRoom.Name + " Player count " + PhotonNetwork.CurrentRoom.PlayerCount);
    }
    #endregion


    #region PRIVATE Methods
    void CreateAndJoinRoom()
    {
        string randomRoomName = "Room" + Random.Range(0, 1000);

        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;

        //Creatin the room
        PhotonNetwork.CreateRoom(randomRoomName, roomOptions);

    }
    #endregion
}
