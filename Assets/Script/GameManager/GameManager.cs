using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private getScore GetScore;
    private UI uI;
    public Dictionary<string, int> CountFruitz;

    void Start()
    {
        CountFruitz = new Dictionary<string, int>()
        {
            {"Apple",0},
            {"Cherry",0},
            {"Grapes",0},
            {"Kiwi",0},
            {"Orange",0},
            {"Watermelon",0},
            {"Bomb",0}
        };
        
        GetScore = FindFirstObjectByType<getScore>();
        uI = FindFirstObjectByType<UI>();
    }
    void Awake()
    {

        if (Instance != null)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    [Header("과일 점수")]
    public int Ascore = 0;
    public int Cscore = 0;
    public int Gscore = 0;
    public int Kscore = 0;
    public int Oscore = 0;
    public int Wscore = 0;

    [Header("지뢰 점수")]
    public int Bombscore = 0;

    [Header("플레이어 정보")]
    public int Total_score = 0;

    [Header("게임 제한 시간")]
    public float limtTime = 120f;

    // public int CountA = 0;
    // public int CountC = 0;
    // public int CountG = 0;
    // public int CountK = 0;
    // public int CountO = 0;
    // public int CountW = 0;
    // public int CountB = 0;
   



    public void CheckFruitz(String fruitzName)
    {
        if (fruitzName == "Apple(Clone)")
        {
            Total_score += Ascore;
            CountFruitz["Apple"] += 1;
            GetScore.lookscore(Ascore);
        }
        else if (fruitzName == "Cherry(Clone)")
        {
            Total_score += Cscore;
            CountFruitz["Cherry"] += 1;
            GetScore.lookscore(Cscore);
        }
        else if (fruitzName == "Grapes(Clone)")
        {
            Total_score += Gscore;
            CountFruitz["Grapes"] += 1;
            GetScore.lookscore(Gscore);
        }
        else if (fruitzName == "Kiwi(Clone)")
        {
            Total_score += Kscore;
            CountFruitz["Kiwi"] += 1;
            GetScore.lookscore(Kscore);
        }
        else if (fruitzName == "Orange(Clone)")
        {
            Total_score += Oscore;
            CountFruitz["Orange"] += 1;
            GetScore.lookscore(Oscore);
        }
        else if (fruitzName == "Watermelon(Clone)")
        {
            Total_score += Wscore;
            CountFruitz["Watermelon"] += 1;
            GetScore.lookscore(Wscore);
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
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void OnRetry()
    {
        // 현재 씬 다시 불러오기
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
