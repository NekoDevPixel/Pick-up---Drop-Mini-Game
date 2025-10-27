using UnityEngine;
using UnityEngine.UI;

public class FeverTime_UI : MonoBehaviour
{
    public Slider FeverSD;
    [Header("피버 스택")]
    public float FeverStack = 10f;
    public float tartgetF = 0f;

    public bool isIncreasing = false;
    public bool isDecreasing = false;

    private const float IncreaseRate = 5f;
    private const float DecayRate = 0.03f;
    private const float Tolerance = 0.01f;

    

    void Start()
    {
        
        FeverSD.value = 0f;
    }

    void Update()
    {
        // 증가 중일 때
        if (isIncreasing)
        {
            FeverSD.value = Mathf.Lerp(FeverSD.value, tartgetF, Time.deltaTime * IncreaseRate);

            if (Mathf.Abs(FeverSD.value - tartgetF) <= Tolerance)
            {
                FeverSD.value = tartgetF;
                isIncreasing = false;
                isDecreasing = true; // 이제 감소 모드로 전환
            }
        }

        // 감소 중일 때
        

        // 최대값 제한
        if (FeverSD.value >= FeverSD.maxValue)
        {
            FeverSD.value = FeverSD.maxValue;
        }
    }

    void FixedUpdate()
    {
        if (isDecreasing)
        {
            FeverSD.value -= DecayRate * Time.deltaTime;
            if (FeverSD.value <= 0f)
            {
                FeverSD.value = 0f;
                tartgetF = 0f;
                isDecreasing = false;
            }
        }
    }

    public void FeverTime(float amount)
    {
        tartgetF = Mathf.Min(tartgetF + amount, FeverSD.maxValue);
        isIncreasing = true;
        isDecreasing = false; // 증가 중에는 감소를 멈춤
        Debug.Log($"Target Fever: {tartgetF}");
    }
}
