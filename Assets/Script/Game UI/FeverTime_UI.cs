using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FeverTime_UI : MonoBehaviour
{
    public Slider FeverSD;
    [Header("피버 스택")]
    public float FeverStack = 10f;
    public float tartgetF = 0f;
    public bool touchF = false;
    private const float IncreaseRate = 5f;

    void Start()
    {
        FeverSD.value = 0f;
    }

    void Update()
    {
        FeverSD.value = Mathf.Lerp(
            FeverSD.value,
            tartgetF,
            Time.deltaTime * IncreaseRate
        );
        if (FeverSD.value >= FeverSD.maxValue)
        {
            FeverSD.value = FeverSD.maxValue;
        }

        const float Tolerance = 0.001f;
        if (Mathf.Abs(FeverSD.value - tartgetF) <= Tolerance)
        {
            FeverSD.value = tartgetF;
            // Lerp가 목표값에 도달했으므로, 이제부터는 감소 로직만 실행됩니다.
            const float DecayRate = 10f;
            FeverSD.value -= DecayRate * Time.deltaTime;
        }
    }
    

    public void FeverTime(float amount)
    {
        tartgetF = Mathf.Min(tartgetF + amount, FeverSD.maxValue);
    }


}
