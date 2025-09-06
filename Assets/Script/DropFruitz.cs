using UnityEngine;

public class DropFruitz : MonoBehaviour
{
    private Collider2D spwBox;
    private Vector2 boxPos;

    private int ChNum;
    public float spTime = 0f;

    public GameObject[] Fruitzs;
    public Transform parent;

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
        if (spTime >= 1f)
        {
            ChNum = Random.Range(0, Fruitzs.Length);
            Instantiate(Fruitzs[ChNum], boxPos, Quaternion.identity, parent);
            spTime = 0f;
        }
        
    }
}
