using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
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
        }
        else if (fruitzName == "Cherry(Clone)")
        {
            Total_score += Cscore;
        }
        else if (fruitzName == "Grapes(Clone)")
        {
            Total_score += Gscore;
        }
        else if (fruitzName == "Kiwi(Clone)")
        {
            Total_score += Kscore;
        }
        else if (fruitzName == "Orange(Clone)")
        {
            Total_score += Oscore;
        }
        else if (fruitzName == "Watermelon(Clone)")
        {
            Total_score += Wscore;
        }
        else if (fruitzName == "Bomb(Clone)")
        {
            if (Total_score >= Bombscore)
            {
                Total_score -= Bombscore;
            }
            else
            {
                Total_score = 0;
            }

        }
    }

}
