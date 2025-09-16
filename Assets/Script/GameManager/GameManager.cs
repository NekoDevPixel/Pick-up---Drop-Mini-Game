using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    private getScore GetScore;

    void Start()
    {
        GetScore = FindFirstObjectByType<getScore>();
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



    public void CheckFruitz(String fruitzName)
    {
        if (fruitzName == "Apple(Clone)")
        {
            Total_score += Ascore;
            GetScore.lookscore(Ascore);
        }
        else if (fruitzName == "Cherry(Clone)")
        {
            Total_score += Cscore;
            GetScore.lookscore(Cscore);
        }
        else if (fruitzName == "Grapes(Clone)")
        {
            Total_score += Gscore;
            GetScore.lookscore(Gscore);
        }
        else if (fruitzName == "Kiwi(Clone)")
        {
            Total_score += Kscore;
            GetScore.lookscore(Kscore);
        }
        else if (fruitzName == "Orange(Clone)")
        {
            Total_score += Oscore;
            GetScore.lookscore(Oscore);
        }
        else if (fruitzName == "Watermelon(Clone)")
        {
            Total_score += Wscore;
            GetScore.lookscore(Wscore);
        }
        else if (fruitzName == "Bomb(Clone)")
        {
            GetScore.lookscore(Bombscore);
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
