using UnityEngine;

public class Store_System : MonoBehaviour
{
    [Header("업그레이드 수치")]
    public float mgTime = 1f;
    public float feverLVG = 0.005f;

    void Start()
    {

    }


    public void upGradeMg()
    {
        GameData.Instance.Ontime += mgTime;
    }

    public void upGradeFeverTime()
    {
        GameData.Instance.DecayRate -= feverLVG;
    }
}
