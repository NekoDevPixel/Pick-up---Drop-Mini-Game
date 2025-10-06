using UnityEngine;

public class Magnet : MonoBehaviour
{

    [Header("플레이어에게 다가가는 속도")]
    public float speed = 5f;
    public GameObject player;
    [Header("스킬 작동 시간")]
    public float Ontime = 20f;

    private float saveT = 0;
    private float gen = 1f;

    public bool ClickMg = false;

    void Start()
    {
        saveT = Ontime;
    }

    void Update()
    {
        Timer();
        if (ClickMg)
        {
            Magnetsk();
            if (gen < 0)
            {
                restT();
            }
        }
    }

    void Timer()
    {
        saveT -= Time.deltaTime;
        gen = saveT / Ontime;
    }

    void Magnetsk()
    {
        GameObject[] targetobj = GameObject.FindGameObjectsWithTag("Fruit");

        for (int i = 0; i < targetobj.Length; i++)
        {
            Vector2 vector2 = (player.transform.position - targetobj[i].transform.position).normalized;
            targetobj[i].transform.position += (Vector3)(vector2 * speed * Time.deltaTime);
        }

    }

    private void restT()
    {
        saveT = Ontime;
        gen = 1f;
        ClickMg = false;
    }
    
    public void Mgbbtn()
    {
        if (!ClickMg)
        {
            ClickMg = true;
        }

    }
}
