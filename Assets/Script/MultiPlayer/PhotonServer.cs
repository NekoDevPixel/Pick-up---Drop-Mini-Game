using Photon.Pun;
using Photon.Realtime;


public class PhotonServer : MonoBehaviourPunCallbacks
{
    public static PhotonServer Instance { get; private set; }

    private MatchUI matchUI;
    private int currentPlayerCount;

    public bool isMulti = false;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        matchUI = FindFirstObjectByType<MatchUI>();
    }

    public void btn()
    {
        
        matchUI.Name[0].text = "서버 접속 중...";
        PhotonNetwork.AutomaticallySyncScene = true;
        isMulti = true;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void quitbtn()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        if (PhotonNetwork.IsConnected)
        {
        PhotonNetwork.Disconnect();
        }
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
        // UpdatePlayerListUI();
    }


    public override void OnJoinedRoom()
    {
        currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        matchUI.Name[0].text = $"방 입장 완료! 현재 인원: {currentPlayerCount} / 2";
        matchUI.Name[1].text = PhotonNetwork.LocalPlayer.NickName;

        UpdatePlayerListUI();
        if (currentPlayerCount == 2)
        { 
            
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
        if (PhotonNetwork.InRoom && PhotonNetwork.CurrentRoom != null)
        {
            currentPlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
        }
        else
        {
            currentPlayerCount = 0;
        }
        matchUI.Name[0].text = $"현재 인원: {currentPlayerCount} / 2";
    }
}