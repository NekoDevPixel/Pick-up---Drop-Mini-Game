using UnityEngine;

public class Store_System : MonoBehaviour
{
    private supply_gold sp_gold;

    [Header("업그레이드 수치")]
    public float mgTime = 1f;
    public float feverLVG = 0.005f;
    public float leverageP = 0.5f;
    public float goldUP = 0.2f;

    [Header("업그레이드스킬당 가격")]
    public int mt = 20;
    public int flvg = 40;
    public int lvgP = 60;
    public int Gup = 80;
    


    void Start()
    {
        sp_gold = FindFirstObjectByType<supply_gold>();
    }


    public void upGradeMg()
    {
        GameData.Instance.Ontime += mgTime;
        sp_gold.buyItem(mt);
    }

    public void upGradeFeverTime()
    {
        GameData.Instance.DecayRate -= feverLVG;
        sp_gold.buyItem(flvg);
    }

    public void upGradeLeverage()
    {
        GameData.Instance.leverage += leverageP;
        sp_gold.buyItem(lvgP);
    }

    public void upGrade_gold()
    {
        GameData.Instance.LVGgold += goldUP;
        sp_gold.buyItem(Gup);
    }
}
