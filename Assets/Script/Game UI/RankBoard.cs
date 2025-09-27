using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework.Constraints;
using TMPro;
using UnityEngine;

public class RankBoard : MonoBehaviour
{
    public GameObject rankboard;
    public TextMeshProUGUI[] rankText;
    private int savescore;


    void Start()
    {
        for (int i = 0; i < rankText.Length; i++)
        {
            rankText[i].text = "";
        }
        rankboard.gameObject.SetActive(false);
    }

    void Update()
    {
        savescore = GameData.Instance.yourScore.Count;
    }

    void LateUpdate()
    {
        int minInt = Math.Min(rankText.Length, savescore);
        addScore();
        for (int i = 0; i < minInt; i++)
        {
            rankText[i].text = $"{GameData.Instance.yourScore[i]} 점";
        }
    }

    public void addScore()
    {
        GameData.Instance.yourScore.Sort();
        GameData.Instance.yourScore.Reverse();
        // Debug.Log(GameData.Instance.yourScore.Count);
    }






    public void Openrankboard()
    {
        rankboard.gameObject.SetActive(true);
    }

    public void Closerankboard()
    {
        rankboard.gameObject.SetActive(false);
    }
}
