using Unity.VisualScripting;
using UnityEngine;

public class Score : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        GameManager.Instance.CheckFruitz(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Fruit"))
        {
            Destroy(collision.gameObject);
        }
    }
}
