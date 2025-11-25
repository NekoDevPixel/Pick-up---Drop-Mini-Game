using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        if (FindObjectsByType<PhotonServer>(FindObjectsSortMode.None).Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    public void btn()
    {
       PhotonNetwork.ConnectUsingSettings(); 
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connect!");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("No room found. Creating a new room.");

        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 2; // 1:1 매칭

        PhotonNetwork.CreateRoom(null, options);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created.");
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined room. Current players: " + PhotonNetwork.CurrentRoom.PlayerCount);

        TryStartGame();
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("Player entered. Current players: " + PhotonNetwork.CurrentRoom.PlayerCount);
        TryStartGame();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogWarning("Disconnected: " + cause);

        // 앱이 포커스를 잃어도 재접속 시도
        if (cause != DisconnectCause.DisconnectByClientLogic)
            PhotonNetwork.ConnectUsingSettings();
    }

    private void TryStartGame()
    {
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            Debug.Log("2 Players in room! Starting game...");

            if (PhotonNetwork.IsMasterClient)
            {
                PhotonNetwork.LoadLevel("InGame");  // 실제 게임 씬으로 이동
            }
        }
    }

    public void CancelMatch()
    {
        PhotonNetwork.LeaveRoom();
    }
}
