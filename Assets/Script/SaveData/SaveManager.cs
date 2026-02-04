using UnityEngine;
using System.Collections;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private GData gData;
    private GameSaveData gameSaveData;

    [Header("Auto Save Settings")]
    public float autoSaveInterval = 30f; // 30초마다 자동 저장

    void Awake()
    {
        // 싱글톤 + 중복 방지
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
        gameSaveData = FindFirstObjectByType<GameSaveData>();

        if (gameSaveData == null)
        {
            Debug.LogError("GameSaveData를 찾을 수 없습니다!");
            return;
        }

        // 데이터 불러오기
        gData = gameSaveData.LoadData();
        ApplyLoadedData();

        // 자동 저장 시작
        StartCoroutine(AutoSaveRoutine());
    }

    IEnumerator AutoSaveRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveInterval);
            inputData();
            Debug.Log("주기적 자동 저장");
        }
    }

    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            inputData();
            Debug.Log("백그라운드 진입 → 자동 저장");
        }
    }

    void OnApplicationQuit()
    {
        inputData();
        Debug.Log("앱 종료 → 자동 저장");
    }

    // 수동 저장 (버튼)
    public void clickbtn()
    {
        inputData();
    }

    // 실제 저장 처리
    public void inputData()
    {
        if (gameSaveData == null || GameData.Instance == null)
            return;

        gData = new GData
        {
            scoreList = GameData.Instance.yourScore,
            Total_score = GameData.Instance.Total_sum_score,
            Slevel = GameData.Instance.level,
            Smgtime = GameData.Instance.Ontime,
            Sdecayrater = GameData.Instance.DecayRate,
            Sleverage = GameData.Instance.leverage,
            Slvhgold = GameData.Instance.LVGgold,
            Sgold = GameData.Instance.gold,
            Sclickbtn = GameData.Instance.clickbtn
        };

        gameSaveData.SaveData(gData);
    }

    // 불러온 데이터 적용
    void ApplyLoadedData()
    {
        if (gData == null || GameData.Instance == null) return;

        GameData.Instance.yourScore = gData.scoreList;
        GameData.Instance.Total_sum_score = gData.Total_score;
        GameData.Instance.level = gData.Slevel;
        GameData.Instance.Ontime = gData.Smgtime;
        GameData.Instance.DecayRate = gData.Sdecayrater;
        GameData.Instance.leverage = gData.Sleverage;
        GameData.Instance.LVGgold = gData.Slvhgold;
        GameData.Instance.gold = gData.Sgold;
        GameData.Instance.clickbtn = gData.Sclickbtn;
    }
}
