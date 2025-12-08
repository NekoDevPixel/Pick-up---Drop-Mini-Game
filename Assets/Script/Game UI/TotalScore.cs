using TMPro;
using UnityEngine;
using UnityEngine.UI;
// [추가] 포톤 관련 네임스페이스
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;
using UnityEngine.SceneManagement;

// [변경] MonoBehaviour -> MonoBehaviourPunCallbacks
public class TotalScore : MonoBehaviourPunCallbacks
{
    public GameObject panel;
    public GameObject scoreImage;
    public GameObject Multipanel;

    public TextMeshProUGUI TTscore;
    
    // [추가] 멀티플레이 결과(승리/패배)를 보여줄 텍스트 (인스펙터에서 연결 필요)
    public TextMeshProUGUI MultiResultText; 

    public float downspeed = 3f;
    private bool end = false;
    private float NTime;
    private float endTime;
    private bool moveimg = false;

    private IngameGold ingameGold;
    public bool finishGame = false;


    void Start()
    {
        endTime = GameManager.Instance.limtTime;
        panel.SetActive(false);
        Multipanel.SetActive(false);
        scoreImage.SetActive(false);
        ingameGold = FindFirstObjectByType<IngameGold>();
        
        // [추가] 멀티플레이 결과 텍스트 초기화 (안 보이게)
        if(MultiResultText != null) MultiResultText.text = "";
    }

    void Update()
    {
        // 이미 끝났으면 실행 X
        if (end) return;

        endTime -= Time.deltaTime;
        NTime = endTime;

        if (NTime <= 0f)
        {
            
            // [변경] 싱글/멀티 분기 처리
            if (PhotonServer.Instance.isMulti)
            {
                // 멀티플레이: 방장(MasterClient)만 종료 신호를 보냄 (중복 실행 방지)
                if (PhotonNetwork.IsMasterClient)
                {
                    photonView.RPC("MultiplayerEndGameRPC", RpcTarget.All);
                }
            }
            else
            {
                // 싱글플레이: 기존 로직 실행
                end_Game();
            }
        }
    }

    void LateUpdate()
    {
        if (moveimg)
        {
            animation_scoreBD();
            if (scoreImage.transform.localPosition.y < 0f)
            {
                moveimg = false;
                // 멀티플레이가 아닐 때만 finishGame 체크 (원래 로직 유지)
                if (!PhotonServer.Instance.isMulti)
                {
                    finishGame = true;
                }
            }
        }
    }

    // [기존] 싱글플레이용 종료 함수
    public void end_Game()
    {
        end = true;
        GameManager.Instance.PauseGame();
        TTscore.text = $"{GameManager.Instance.Total_score}";
        
        if (!PhotonServer.Instance.isMulti)
        {
            if (ingameGold != null) ingameGold.plusFruitz_Gold();
            scoreManager();
            panel.SetActive(true);
            scoreImage.SetActive(true);
        }
        
        
        moveimg = true;
    }

    [PunRPC]
    public void MultiplayerEndGameRPC()
    {
        end = true;
        GameManager.Instance.PauseGame(); 
        panel.SetActive(true);
        Hashtable props = new Hashtable { { "Score", GameManager.Instance.Total_score } };
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);

        CalculateMultiResult();
    }

    void CalculateMultiResult()
    {

        if (MultiResultText != null) MultiResultText.text = "";

        // 2. 상대방이 진짜 방에 있는지 확인 (점수 프로퍼티 유무로 확인하면 안됨!)
        if (PhotonNetwork.PlayerListOthers.Length == 0)
        {
             if (MultiResultText != null)
                MultiResultText.text = "상대방이 나갔습니다.\n승리!";
             return;
        }

        int myScore = GameManager.Instance.Total_score;
        int otherScore = 0;
        string otherName = "상대방";

 
        foreach (Player p in PhotonNetwork.PlayerListOthers)
        {
            otherName = p.NickName; 
            

            if (p.CustomProperties.ContainsKey("Score"))
            {
                otherScore = (int)p.CustomProperties["Score"];
            }
            else
            {
                otherScore = 0; 
            }
        }


        if (MultiResultText != null)
        {

            string resultMsg = $"나: {myScore}점\n{otherName}: {otherScore}점\n\n";

            if (myScore > otherScore) 
            {
                resultMsg += "승리!";
            }
            else if (myScore < otherScore) 
            {
                resultMsg += "패배..."; 
            }
            else 
            {
                resultMsg += "무승부"; 
            }

            MultiResultText.text = resultMsg;
        }
        Multipanel.SetActive(true);
    }

    void animation_scoreBD()
    {

        scoreImage.transform.localPosition += Vector3.down * downspeed * Time.unscaledDeltaTime;
    }

    void scoreManager()
    {
        GameData.Instance.yourScore.Add(GameManager.Instance.Total_score);
        GameData.Instance.Total_sum_score += GameManager.Instance.Total_score;
    }

    public void btn()
    {
        PhotonNetwork.LeaveRoom();
        PhotonNetwork.Disconnect();
        SceneManager.LoadScene("MainMenu");
    }
}