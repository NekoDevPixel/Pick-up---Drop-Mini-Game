using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    // public int Fscore;
    public List<int> yourScore = new List<int>();
    public int Total_sum_score = 0;

    [Header("게임스킬On_Off")]
    public bool onSkill_mg = false;
    public bool onSkill_chg = false;

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
}
