using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CoLTimeUI : MonoBehaviour
{
    public Image MGbtn;
    public float maxTime = 30f;
    private float savetime;

    private bool clickbtn = false;
    private Magnet magnet;

    void Start()
    {
        magnet = FindFirstObjectByType<Magnet>();
        savetime = maxTime;
        MGbtn.fillAmount = 0f;
    }

    void Update()
    {
        savetime -= Time.deltaTime;
        if (clickbtn)
        {
            Cooltime();
            if (MGbtn.fillAmount == 0)
            {
                restTime();
            }
        }
    }
    public void Cooltime()
    {
        MGbtn.fillAmount = savetime / maxTime;
    }

    public void clickMgbtn()
    {
        clickbtn = true;
        magnet.onSkill = true;
        MGbtn.fillAmount = 1f;
    }

    // public void clickChange()
    // {
    //     clickbtn = true;
    //     probbtn.onSkill = true;
    //     MGbtn.fillAmount = 1f;
    // }

    private void restTime()
    {
        savetime = maxTime;
        clickbtn = false;
    }
}
