using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    // public int Fscore;
    public List<int> yourScore = new List<int>();
    public int Total_sum_score = 0;

    [Header("게임스킬On_Off")]
    public bool onSkill_mg = false;

    [Header("자석스킬 지속시간")]
    public float Ontime = 10f;
    [Header("피버타임 지속시간")]
    public float DecayRate = 0.3f;
    [Header("레버리지")]
    public float leverage = 1.3f;
    [Header("골드량")]
    public int gold = 0;
    [Header("골드 획득배율")]
    public float LVGgold = 1.0f;

    public int[] level = new int[]
    {
        0,
        0,
        0,
        0,
    };

    private GameSaveData gameSaveData;
    public bool clickbtn =false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        gameSaveData = FindFirstObjectByType<GameSaveData>();
        // SkillData skillData = gameSaveData.KLoadData();
        GData gData = gameSaveData.LoadData();
        // ScoreData scoreData = gameSaveData.CLoadData();

        Total_sum_score = gData.Total_score;
        
        yourScore = gData.scoreList;

        level = gData.Slevel;
        Ontime = gData.Smgtime;
        DecayRate = gData.Sdecayrater;
        leverage = gData.Sleverage;
        gold = gData.Sgold;
        LVGgold = gData.Slvhgold;
        clickbtn = gData.Sclickbtn;
    }

    


}
