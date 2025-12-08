using System;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private getScore GetScore;
    private UI uI;
    public Dictionary<string, int> CountFruitz;

    private Fever fever;

    void Start()
    {
        CountFruitz = new Dictionary<string, int>()
        {
            {"Apple",0},
            {"Watermelon",0},
            {"Grapes",0},
            {"Kiwi",0},
            {"Orange",0},
            {"Cherry",0},
            {"Bomb",0}
        };
        fever = FindFirstObjectByType<Fever>();
        
    }
    void Awake()
    {
        if (Instance != null) { Destroy(this); } else { Instance = this; }
        GetScore = FindFirstObjectByType<getScore>();
        uI = FindFirstObjectByType<UI>();
    }

    [Header("과일 점수")]
    public int[] Fscore = new int[6];

    [Header("지뢰 점수")]
    public int Bombscore = 0;

    [Header("플레이어 정보")]
    public int Total_score = 0;

    [Header("게임 제한 시간")]
    public float limtTime = 120f;
    

    public void CheckFruitz(String fruitzName)
    {
        if (fruitzName == "Apple(Clone)")
        {
            fever.FeverScore(Fscore[0]);
            CountFruitz["Apple"] += 1;
            GetScore.lookscore(Fscore[0]);
        }
        else if (fruitzName == "Cherry(Clone)")
        {
            fever.FeverScore(Fscore[1]);
            CountFruitz["Cherry"] += 1;
            GetScore.lookscore(Fscore[1]);
        }
        else if (fruitzName == "Grapes(Clone)")
        {
            fever.FeverScore(Fscore[2]);
            CountFruitz["Grapes"] += 1;
            GetScore.lookscore(Fscore[2]);
        }
        else if (fruitzName == "Kiwi(Clone)")
        {
            fever.FeverScore(Fscore[3]);
            CountFruitz["Kiwi"] += 1;
            GetScore.lookscore(Fscore[3]);
        }
        else if (fruitzName == "Orange(Clone)")
        {
            fever.FeverScore(Fscore[4]);
            CountFruitz["Orange"] += 1;
            GetScore.lookscore(Fscore[4]);
        }
        else if (fruitzName == "Watermelon(Clone)")
        {
            fever.FeverScore(Fscore[5]);
            CountFruitz["Watermelon"] += 1;
            GetScore.lookscore(Fscore[5]);
        }
        else if (fruitzName == "Bomb(Clone)")
        {
            GetScore.lookscore(Bombscore);
            CountFruitz["Bomb"] += 1;
            if (Total_score >= Math.Abs(Bombscore))
            {
                Total_score += Bombscore;
            }
            else
            {
                Total_score = 0;
            }

        }

        UpdateNetworkScore(Total_score);
    }

    public void UpdateNetworkScore(int score)
    {
        // 멀티플레이 상태가 아니면 실행 안 함 (오류 방지)
        if (PhotonNetwork.IsConnected == false) return;

        Hashtable props = new Hashtable();
        props.Add("Score", score); // "Score"라는 이름표로 내 점수 저장
        PhotonNetwork.LocalPlayer.SetCustomProperties(props);
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void OnRetry()
    {
        // 현재 씬 다시 불러오기
        SceneManager.LoadScene("InGame");
        Time.timeScale = 1f;
    }
    
    public void GoMain()
    {
        // 현재 씬 다시 불러오기
        SceneManager.LoadScene("MainMenu");
    }
}
