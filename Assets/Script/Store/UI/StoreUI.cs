using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    [Header("상점UI")]
    public GameObject Store;
    // private bool checkbtn = false;

    [Header("상점 아이템 텍스트")]
    public TextMeshProUGUI[] item;

    public int[] level = new int[4];
    private String[] Itext = new string[]
    {
        "피버타임 Up Lv.",
        "피버배율 Up Lv.",
        "자석 타임 Up Lv.",
        "골드 수급 Up Lv."
    };

    public int maxlevel = 5;
    private Store_System store_System;
    private supply_gold sp_gold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0; i < level.Length; i++)
        {
            level[i] = 0;
            item[i].text = $"{Itext[i]}{level[i]}";
        }
        // Store.SetActive(false);
        store_System = FindFirstObjectByType<Store_System>();
        sp_gold = FindFirstObjectByType<supply_gold>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //GUI텍스트 오브젝트가 순서대로 있다는 가정하에
    public void feverTime_Up()
    {
        if(GameData.Instance.gold - store_System.flvg >= 0)
        {
            if(maxlevel != level[0])
            {
                level[0] += 1;
                item[0].text = $"{Itext[0]}{level[0]}";
                store_System.upGradeFeverTime();
            }
        }
        
    }

    public void feverTimeLeverage_Up()
    {
        if(maxlevel != level[1])
        {
            level[1] += 1;
            item[1].text = $"{Itext[1]}{level[1]}";
        }
    }

    public void mg_Up()
    {
        if(GameData.Instance.gold - store_System.mt >= 0)
        {
            if(maxlevel != level[2])
            {
                level[2] += 1;
                item[2].text = $"{Itext[2]}{level[2]}";
                store_System.upGradeMg();
            }
        }
        
    }
    
    public void gld_Up()
    {
        if(maxlevel != level[3])
        {
            level[3] += 1;
            item[3].text = $"{Itext[3]}{level[3]}";
        }
    }

    public void CloseST()
    {
        Store.SetActive(false);
    }

    public void ClickST()
    {
        Store.SetActive(true);
    }


}
