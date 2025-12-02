using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Text.RegularExpressions;
using System.IO;
using ExitGames.Client.Photon;

public class PhotonServer : MonoBehaviourPunCallbacks
{

    private MatchUI matchUI;
    private int currentPlayerCount;

    public bool isMulti = false;
    void Start()
    {
        matchUI = FindFirstObjectByType<MatchUI>();
       
        
    }

    public void btn()
    {
        
        matchUI.Name[0].text = "서버 접속 중...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void quitbtn()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        matchUI.NameUI.SetActive(true);
        matchUI.RoomUI.SetActive(false);
        matchUI.Name[1].text = "";
        isMulti = false;
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        matchUI.Name[3].text = "";
        // matchUI.Name[0].text = $"현재 인원: {currentPlayerCount} / 2";
        // if(currentPlayerCount == 0)
        // {
        //     matchUI.Name[0].text = "";
        // }
    }

    public override void OnConnectedToMaster()
    {
        matchUI.Name[0].text = "빈 방 찾는 중...";
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        matchUI.Name[0].text = "빈 방이 없음. 새로운 방 생성...";

        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(null, roomOptions);
        UpdatePlayerListUI();
    }


    public override void OnJoinedRoom()
    {
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        matchUI.Name[0].text = $"방 입장 완료! 현재 인원: {currentPlayerCount} / 2";
        matchUI.Name[1].text = PhotonNetwork.LocalPlayer.NickName;

        UpdatePlayerListUI();
        if (currentPlayerCount == 2)
        { 
            isMulti = true;
            StartGame();
        }
        else
        {

            matchUI.Name[0].text = "상대방 기다리는 중...";
        }
    }


    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        matchUI.Name[0].text = "상대방 입장!";
        matchUI.Name[3].text += $"{newPlayer.NickName}님이 입장하셨습니다.\n";
        UpdatePlayerCountUI();
        UpdatePlayerListUI();

        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            StartGame();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        matchUI.Name[3].text += $"{otherPlayer.NickName}님이 퇴장하셨습니다.\n";
        matchUI.Name[2].text = "상대방 없음"; 
        UpdatePlayerCountUI();
    
    }

    // public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    // {
    //     if (changedProps.ContainsKey("score"))
    //     {
    //         CheckBothPlayersScore();
    //     }
    // }

    // void CheckBothPlayersScore()
    // {
    //     Player p1 = PhotonNetwork.PlayerList[0];
    //     Player p2 = PhotonNetwork.PlayerList[1];

    //     if (p1.CustomProperties.ContainsKey("score") &&
    //         p2.CustomProperties.ContainsKey("score"))
    //     {
    //         int score1 = (int)p1.CustomProperties["score"];
    //         int score2 = (int)p2.CustomProperties["score"];

    //         CompareScore(score1, score2);
    //     }
    // }

    // void CompareScore(int score1, int score2)
    // {
    //     if (score1 > score2)
    //     {
    //         Debug.Log("Player 1 승리!");
    //     }
    //     else if (score2 > score1)
    //     {
    //         Debug.Log("Player 2 승리!");
    //     }
    //     else
    //     {
    //         Debug.Log("무승부!");
    //     }
    // }

    void StartGame()
    {
        // 방장(MasterClient)만 씬을 로딩하도록 함
        if (PhotonNetwork.IsMasterClient)
        {
            // "GameScene" 부분에 실제 게임 씬 이름을 적어주세요.
            // File > Build Settings에 해당 씬이 등록되어 있어야 합니다.
            PhotonNetwork.LoadLevel("InGame");
        }
    }

    void UpdatePlayerListUI()
    {
        matchUI.Name[1].text = PhotonNetwork.LocalPlayer.NickName;

        if (PhotonNetwork.PlayerListOthers.Length > 0)
            matchUI.Name[2].text = PhotonNetwork.PlayerListOthers[0].NickName;
        else
            matchUI.Name[2].text = "상대 없음";
    }

    private void UpdatePlayerCountUI()
    {
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        matchUI.Name[0].text = $"현재 인원: {currentPlayerCount} / 2";
    }
    
    // public void SubmitScore(int score)
    // {
    //     Hashtable hash = new Hashtable();
    //     hash["score"] = score;

    //     PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    // }
}