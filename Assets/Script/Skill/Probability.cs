using UnityEditor;
using UnityEngine;

public class Probability : MonoBehaviour
{
    private DropFruitz dropFruitz;
    private float saveFprop = 0f;
    private float saveBprop = 0f;
    private bool ClickProp = false;
    public bool onSkill = false;

    [Header("변경 확률 값")]
    public float fruitProp = 0.9f;
    public float bombProp = 0.1f;
    [Header("스킬 발동 시간")]
    public float Ontime = 10f;

    private float saveT = 0;
    private float gen = 1f;
    void Start()
    {
        dropFruitz = FindAnyObjectByType<DropFruitz>();
        saveT = Ontime;
        saveBprop = dropFruitz.Bombprob;
        saveFprop = dropFruitz.Fruitprob;
    }

    private void Update()
    {
        Timer();
        if (ClickProp)
        {
            dropFruitz.Bombprob = bombProp;
            dropFruitz.Fruitprob = fruitProp;
            if (saveT <= 0)
            {
                
                resetProp();
            }
        }
    }

    void Timer()
    {
        saveT -= Time.deltaTime;
        gen = saveT / Ontime;
    }
    public void probbtn()
    {
        if (!ClickProp)
        {
            ClickProp = true;
        }

    }

    private void resetProp()
    {
        dropFruitz.Bombprob = saveBprop;
        dropFruitz.Fruitprob = saveFprop;
        saveT = Ontime;
        gen = 1f;
        ClickProp = false;
    }
}
