using UnityEngine;
using System;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class ScoreData
{
    public List<int> scoreList;
}

[System.Serializable]
public class SkillData
{
    public int Total_score;
}
[System.Serializable]
public class StoreData
{
    public int[] Slevel;
    public float Smgtime;
    public float Sdecayrater;
    public float Sleverage;
    public float Slvhgold;
    public int Sgold;
}

public class GameSaveData : MonoBehaviour
{
    private string scorefile;
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
        scorefile = Application.persistentDataPath + "/scoreData.json";
        skillfile = Application.persistentDataPath + "/skillData.json";
        storefile = Application.persistentDataPath + "/storeData.json";
        Debug.Log("파일 경로 초기화: " + scorefile);
        Debug.Log("파일 경로 초기화: " + skillfile);
        Debug.Log("파일 경로 초기화: " + storefile);
    }
    public void SaveDataK(SkillData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(skillfile, jsonData);
        Debug.Log("Json 파일로 저장됨: " + skillfile);
    }
    public void SaveDataC(ScoreData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(scorefile, jsonData);
        Debug.Log("Json 파일로 저장됨: " + scorefile);
    }
    public void SaveDataT(StoreData data)
    {
        string jsonData = JsonUtility.ToJson(data, true);
        File.WriteAllText(storefile, jsonData);
        Debug.Log("Json 파일로 저장됨: " + storefile);
    }

    public ScoreData CLoadData()
    {
        Debug.Log("파일 경로: " + scorefile);
        if (File.Exists(scorefile))
        {
            string jsonData = File.ReadAllText(scorefile);
            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonData);
            Debug.Log("Json 파일 불러오기 완료!");
            return data;
        }
        else
        {
            Debug.Log("저장된 데이터 없음. 새 데이터 생성");
            return new ScoreData { scoreList = new List<int>() };
        }
    }

    public SkillData KLoadData()
    {
        Debug.Log("파일 경로: " + skillfile);
        if (File.Exists(skillfile))
        {
            string jsonData = File.ReadAllText(skillfile);
            SkillData data = JsonUtility.FromJson<SkillData>(jsonData);
            Debug.Log("Json 파일 불러오기 완료!");
            return data;
        }
        else
        {
            Debug.Log("저장된 데이터 없음. 새 데이터 생성");
            return new SkillData { Total_score = 0 };
        }
    }

    public StoreData TLoadData()
    {
        Debug.Log("파일 경로: " + storefile);
        if (File.Exists(storefile))
        {
            string jsonData = File.ReadAllText(storefile);
            StoreData data = JsonUtility.FromJson<StoreData>(jsonData);
            Debug.Log("Json 파일 불러오기 완료!");
            return data;
        }
        else
        {
            Debug.Log("저장된 데이터 없음. 새 데이터 생성");
            return new StoreData { 
                Slevel = new int[4],
                Smgtime = 10f,
                Sdecayrater = 0.3f,
                Sleverage = 1.3f,
                Sgold = 0,
                Slvhgold = 1.0f
            };
        }
    }

}
