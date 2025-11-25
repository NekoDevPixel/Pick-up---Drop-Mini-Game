using UnityEngine;

public class SaveManager : MonoBehaviour
{
    // private StoreUI storeUI;

    // private ScoreData scoreData;
    private GData gData;
    // private SkillData skillData;

    private GameSaveData gameSaveData;

    void Awake()
    {
        // if (FindObjectsByType<SaveManager>(FindObjectsSortMode.None).Length > 1)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // DontDestroyOnLoad(gameObject);
        
    }

    void Start()
    {
        gameSaveData = FindFirstObjectByType<GameSaveData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickbtn()
    {
        inputData();
        // inputSkillData();
        // inputStoreData();
    }

    public void inputData()
    {
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

    // public void inputSkillData()
    // {
    //     skillData = new SkillData{Total_score = GameData.Instance.Total_sum_score};
    //     gameSaveData.SaveDataK(skillData);
    // }

    // public void inputStoreData()
    // {
    //     storeData = new StoreData
    //     {
    //         Slevel = GameData.Instance.level,
    //         Smgtime = GameData.Instance.Ontime,
    //         Sdecayrater = GameData.Instance.DecayRate,
    //         Sleverage = GameData.Instance.leverage,
    //         Slvhgold = GameData.Instance.LVGgold,
    //         Sgold = GameData.Instance.gold,
    //         Sclickbtn = GameData.Instance.clickbtn
    //     };
    //     gameSaveData.SaveDataT(storeData);
    // }
}
