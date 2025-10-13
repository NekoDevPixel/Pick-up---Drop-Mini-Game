using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class SkillBoard : MonoBehaviour
{
    public GameObject skillboard;
    private bool boardonff = false;

    [Header("자석스킬")]
    public TextMeshProUGUI Mgbtn;
    public bool onSkill_mg = false;

    [Header("체인지스킬")]
    public TextMeshProUGUI chgbtn;
    public bool onSkill_chg = false;

    [Header("해방 조건 확인")]
    public GameObject OnOffBoard;
    public TextMeshProUGUI onoffsk;

    private float ontime = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        skillboard.SetActive(false);
        OnOffBoard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clearMgSkill()
    {
        if (GameData.Instance.Total_sum_score > 300)
        {
            onoffsk.text = "스킬 해방이 성공하였습니다.";
            Mgbtn.text = "해방 완료";
        }
        else
        {
            onoffsk.text = "해방 조건을 달성하지 못했습니다.";
        }
    }
    
    public void clearChgSkill()
    {
        if (GameData.Instance.Total_sum_score > 600)
        {
            onoffsk.text = "스킬 해방이 성공하였습니다.";
            chgbtn.text = "해방 완료";
        }
        else
        {
            
            onoffsk.text = "해방 조건을 달성하지 못했습니다.";
        }
    }

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
