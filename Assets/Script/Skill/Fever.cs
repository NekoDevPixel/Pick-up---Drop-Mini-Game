using Unity.VisualScripting;
using UnityEngine;

public class Fever : MonoBehaviour
{
    private FeverTime_UI feverTime_UI;

    public bool fullSD = false;
    private const float DecayRate = 0.3f;
    [Header("레버리지")]
    public float leverage = 1.3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        feverTime_UI = FindFirstObjectByType<FeverTime_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        FeverT();
    }

    void FeverT()
    {
        if (feverTime_UI.FeverSD.value == 1)
        {
            feverTime_UI.isIncreasing = false;
            feverTime_UI.isDecreasing = false;
            fullSD = true;
        }
        if (fullSD)
        {
            feverTime_UI.FeverSD.value -= DecayRate * Time.deltaTime;
            if (feverTime_UI.FeverSD.value <= 0)
            {
                fullSD = false;
                feverTime_UI.tartgetF = 0f;
            }
        }
    }
    
    public void FeverScore(int score)
    {
        if (fullSD)
        {
            GameManager.Instance.Total_score += (int)(score * leverage);
            Debug.Log(score * leverage);
        }
        else
        {
            GameManager.Instance.Total_score += score;
        }
    }
}
