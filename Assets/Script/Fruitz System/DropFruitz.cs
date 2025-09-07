using UnityEngine;

public class DropFruitz : MonoBehaviour
{
    private Collider2D spwBox;
    private Vector2 boxPos;

    private int ChNum;
    [Header("실시간 타임")]
    public float spTime = 0f;
    [Header("초기화 지점 타임")]
    public float ResetTime = 1f;

    [Header("생성될 게임오브젝트")]
    public GameObject[] Fruitzs;

    public Transform parent;

    [Header("과일 생성 확률(0~1)(폭탄 생성 확률과 과일 생성 확률의 합은 1)")]
    public float Fruitprob = 0.5f;

    [Header("폭탄 생성 확률(0~1)")]
    public float Bombprob = 0.5f;

    void Start()
    {
        spwBox = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        spTime += Time.deltaTime;
        spwPos();
        spwFruitz();

    }

    void spwPos()
    {
        Bounds bounds = spwBox.bounds;
        boxPos = new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
        );


    }

    void spwFruitz()
    {
        float rand = Random.value;
        if (spTime >= ResetTime)
        {
            if (rand < Bombprob)
            {
                Instantiate(Fruitzs[6], boxPos, Quaternion.identity, parent);
                spTime = 0f;
            }
            else if (rand < Bombprob + Fruitprob)
            {
                ChNum = Random.Range(0, Fruitzs.Length);
                Instantiate(Fruitzs[ChNum], boxPos, Quaternion.identity, parent);
                spTime = 0f;
            }
            
        }
        
    }
}
