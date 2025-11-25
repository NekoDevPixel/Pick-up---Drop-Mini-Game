using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class ScoreData
{
    // public List<int> scoreList;
}

[System.Serializable]
public class SkillData
{
    // public int Total_score;
}
[System.Serializable]
public class GData
{
    public int Total_score;    
    public List<int> scoreList;
    public int[] Slevel;
    public float Smgtime;
    public float Sdecayrater;
    public float Sleverage;
    public float Slvhgold;
    public int Sgold;
    public bool Sclickbtn;
}

public class GameSaveData : MonoBehaviour
{
    private string gfile;
    private string skillfile;
    private string storefile;

    

    void Awake()
    {
        // if (FindObjectsByType<GameSaveData>(FindObjectsSortMode.None).Length > 1)
        // {
        //     Destroy(gameObject);
        //     return;
        // }
        // DontDestroyOnLoad(gameObject);
        gfile = Application.persistentDataPath + "/gameData.json";
        // skillfile = Application.persistentDataPath + "/skillData.json";
        // storefile = Application.persistentDataPath + "/storeData.json";
        Debug.Log("파일 경로 초기화: " + gfile);
    }
    // public void SaveDataK(SkillData data)
    // {
    //     string jsonData = JsonUtility.ToJson(data, true);
    //     File.WriteAllText(skillfile, jsonData);
    //     Debug.Log("Json 파일로 저장됨: " + skillfile);
    // }
    public void SaveData(GData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(gfile, jsonData);
        Debug.Log("Json 파일로 저장됨: " + gfile);
    }
    // public void SaveDataT(StoreData data)
    // {
    //     string jsonData = JsonUtility.ToJson(data, true);
    //     File.WriteAllText(storefile, jsonData);
    //     Debug.Log("Json 파일로 저장됨: " + storefile);
    // }

    public GData LoadData()
    {
        Debug.Log("파일 경로: " + gfile);
        if (File.Exists(gfile))
        {
            string jsonData = File.ReadAllText(gfile);
            GData data = JsonUtility.FromJson<GData>(jsonData);
            Debug.Log("Json 파일 불러오기 완료!");
            return data;
        }
        else
        {
            Debug.Log("저장된 데이터 없음. 새 데이터 생성");
            return new GData { 
                scoreList = new List<int>(),
                Total_score = 0,
                Slevel = new int[4],
                Smgtime = 10f,
                Sdecayrater = 0.3f,
                Sleverage = 1.3f,
                Sgold = 0,
                Slvhgold = 1.0f,
                Sclickbtn = false
             };
        }
    }

    // public SkillData KLoadData()
    // {
    //     Debug.Log("파일 경로: " + skillfile);
    //     if (File.Exists(skillfile))
    //     {
    //         string jsonData = File.ReadAllText(skillfile);
    //         SkillData data = JsonUtility.FromJson<SkillData>(jsonData);
    //         Debug.Log("Json 파일 불러오기 완료!");
    //         return data;
    //     }
    //     else
    //     {
    //         Debug.Log("저장된 데이터 없음. 새 데이터 생성");
    //         return new SkillData { Total_score = 0 };
    //     }
    // }

    // public StoreData TLoadData()
    // {
    //     Debug.Log("파일 경로: " + storefile);
    //     if (File.Exists(storefile))
    //     {
    //         string jsonData = File.ReadAllText(storefile);
    //         StoreData data = JsonUtility.FromJson<StoreData>(jsonData);
    //         Debug.Log("Json 파일 불러오기 완료!");
    //         return data;
    //     }
    //     else
    //     {
    //         Debug.Log("저장된 데이터 없음. 새 데이터 생성");
    //         return new StoreData { 
    //             Slevel = new int[4],
    //             Smgtime = 10f,
    //             Sdecayrater = 0.3f,
    //             Sleverage = 1.3f,
    //             Sgold = 0,
    //             Slvhgold = 1.0f,
    //             Sclickbtn = false
    //         };
    //     }
    // }

}
