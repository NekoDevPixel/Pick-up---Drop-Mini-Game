using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    private getScore getScore;

    void Start()
    {
        // getScore = FindFirstObjectByType<getScore>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // getScore.mPostext = true;
        Debug.Log(collision.gameObject.name);
        GameManager.Instance.CheckFruitz(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Fruit") || collision.gameObject.CompareTag("Bomb"))
        {
            Destroy(collision.gameObject);
        }
    }
}
