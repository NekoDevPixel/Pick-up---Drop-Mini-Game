using UnityEngine;

public class Liberation : MonoBehaviour
{
    public GameObject seal1;
    public GameObject seal2;

    private bool checkchg = false;

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
        if (GameData.Instance.Total_sum_score > 300)
        {
            seal1.SetActive(false);
        }
        else if (GameData.Instance.Total_sum_score > 600) {
            seal2.SetActive(false);
        }
    }
}
