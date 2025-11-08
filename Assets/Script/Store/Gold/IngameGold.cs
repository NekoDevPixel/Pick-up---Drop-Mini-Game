using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IngameGold : MonoBehaviour
{
    public TextMeshProUGUI goldtext;
    private int sumGold = 0;

    private String[] fruitz = new string[]{
        "Apple",
        "Cherry",
        "Grapes",
        "Kiwi",
        "Orange",
        "Watermelon"
    };

    private int[] fruGold = new int[] { 15,10,8,6,4,2 };
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void plusFruitz_Gold()
    {
        for (int i = 0; i < fruitz.Length; i++)
        {
            sumGold += (int)(GameManager.Instance.CountFruitz[fruitz[i]] * fruGold[i] * GameData.Instance.LVGgold);
        }
        goldtext.text = $"{sumGold}";
        GameData.Instance.gold = sumGold;
    }
}
