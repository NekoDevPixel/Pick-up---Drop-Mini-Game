using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    private FeverTime_UI feverTime_UI;

    void Start()
    {
        feverTime_UI = FindFirstObjectByType<FeverTime_UI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // getScore.mPostext = true;
        Debug.Log(collision.gameObject.name);
        GameManager.Instance.CheckFruitz(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Bomb"))
        {
            if (collision.gameObject.CompareTag("Fruit"))
            {
                feverTime_UI.FeverTime(0.1f);
            }
            Destroy(collision.gameObject);
        }
    }
}
