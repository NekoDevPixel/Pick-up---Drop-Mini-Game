using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SkillBoard : MonoBehaviour
{
    public GameObject skillboard;
    private bool boardonff = false;

    [Header("자석스킬")]
    public TextMeshProUGUI Mgbtn;
    

    [Header("해방 조건 확인")]
    public GameObject OnOffBoard;
    public TextMeshProUGUI onoffsk;

    private float ontime = 1f;
    private float savetime = 0f;
    private float istime = 0f;
    private bool isbtn = false;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savetime = ontime;
        skillboard.SetActive(false);
        OnOffBoard.SetActive(false);
        if (GameData.Instance.Total_sum_score >= 300 && GameData.Instance.clickbtn)
        {
            GameData.Instance.onSkill_mg = true;
            Mgbtn.text = "해방 완료";
        }
        
    }
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isbtn)
        {
            ontime -= Time.unscaledDeltaTime;
            istime = ontime;
            if(istime <= 0)
            {
                OnOffBoard.SetActive(false);
                ontime = savetime;
                isbtn = false;
            }
        }
    }

    public void clearMgSkill()
    {
        OnOffBoard.SetActive(true);
        isbtn = true;
        if (GameData.Instance.Total_sum_score >= 300 && !GameData.Instance.clickbtn)
        {
            GameData.Instance.clickbtn = true;
            onoffsk.text = "스킬 해방이 성공하였습니다.";
            Mgbtn.text = "해방 완료";
            GameData.Instance.onSkill_mg = true;
        }
        else if (GameData.Instance.onSkill_mg && GameData.Instance.clickbtn)
        {
            onoffsk.text = "이미 스킬 해방이 완료되었습니다..";
        }
        else
        {
            onoffsk.text = "해방 조건을 달성하지 못했습니다.";
        }
    }
    
    // public void clearChgSkill()
    // {
    //     OnOffBoard.SetActive(true);
    //     isbtn = true;
    //     if (GameData.Instance.Total_sum_score >= 600)
    //     {
    //         onoffsk.text = "스킬 해방이 성공하였습니다.";
    //         chgbtn.text = "해방 완료";
    //         GameData.Instance.onSkill_chg = true;
    //     }
    //     else
    //     {
            
    //         onoffsk.text = "해방 조건을 달성하지 못했습니다.";
    //     }
    // }

    public void onBoard()
    {
        if (!boardonff)
        {
            skillboard.SetActive(true);
            boardonff = true;
        }

    }
    public void offBoard()
    {
        if (boardonff)
        {
            skillboard.SetActive(false);
            boardonff = false;
        }   
    }
}
