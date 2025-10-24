using UnityEngine;

public class Liberation : MonoBehaviour
{
    public GameObject seal1;
    public GameObject seal2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        openskill();
    }

    void openskill()
    {
        if (GameData.Instance.onSkill_mg)
        {
            seal1.SetActive(false);
            GameData.Instance.onSkill_mg = false;
        }
        if (GameData.Instance.onSkill_chg) {
            seal2.SetActive(false);
            GameData.Instance.onSkill_chg = false;
        }
    }
}
