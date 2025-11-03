using UnityEngine;

public class Liberation : MonoBehaviour
{
    public GameObject seal1;


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
    }
}
