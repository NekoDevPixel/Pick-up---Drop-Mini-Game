using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.Text.RegularExpressions;
using System.IO;

public class PhotonServer : MonoBehaviourPunCallbacks
{

    private MatchUI matchUI;
    private int currentPlayerCount;
    void Start()
    {
        matchUI = FindFirstObjectByType<MatchUI>();
       
        
    }

    public void btn()
    {
         // 1. 게임 시작 시 자동으로 포튼 서버 접속
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

        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        // matchUI.Name[0].text = $"현재 인원: {currentPlayerCount} / 2";
        // if(currentPlayerCount == 0)
        // {
        //     matchUI.Name[0].text = "";
        // }
    }

    public override void OnConnectedToMaster()
    {
        // 2. 서버 접속 완료되면 바로 방 찾기 시도
        matchUI.Name[0].text = "빈 방 찾는 중...";
        PhotonNetwork.JoinRandomRoom();
    }

    // 3. 빈 방 찾기 실패 (방이 없거나 꽉 참) -> 내가 방을 새로 만듦
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        matchUI.Name[0].text = "빈 방이 없음. 새로운 방 생성...";
        // 중요: 최대 인원을 2명으로 제한
        RoomOptions roomOptions = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(null, roomOptions);
        UpdatePlayerListUI();
    }

    // 4. 방 입장 성공 (방장이든 참가자든 이 함수가 호출됨)
    public override void OnJoinedRoom()
    {
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        matchUI.Name[0].text = $"방 입장 완료! 현재 인원: {currentPlayerCount} / 2";
        matchUI.Name[1].text = PhotonNetwork.LocalPlayer.NickName;

        UpdatePlayerListUI();
        if (currentPlayerCount == 2)
        {
            // 내가 들어갔는데 이미 2명이 되었다면 바로 게임 시작
            StartGame();
        }
        else
        {
            // 아직 나 혼자라면 대기
            matchUI.Name[0].text = "상대방 기다리는 중...";
        }
    }

    // 5. 다른 플레이어가 방에 들어왔을 때 (내가 방장이고 기다리던 상황)
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        matchUI.Name[0].text = "상대방 입장!";
        matchUI.Name[3].text += $"{newPlayer.NickName}님이 입장하셨습니다.\n";
        UpdatePlayerCountUI();
        UpdatePlayerListUI();
        // 방에 2명이 찼는지 확인
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            // StartGame();
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        matchUI.Name[3].text += $"{otherPlayer.NickName}님이 퇴장하셨습니다.\n";
        matchUI.Name[2].text = "상대방 없음";
        UpdatePlayerCountUI();
    
    }

    void StartGame()
    {
        // 방장(MasterClient)만 씬을 로딩하도록 함
        if (PhotonNetwork.IsMasterClient)
        {
            // "GameScene" 부분에 실제 게임 씬 이름을 적어주세요.
            // File > Build Settings에 해당 씬이 등록되어 있어야 합니다.
            PhotonNetwork.LoadLevel("GameScene");
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
}