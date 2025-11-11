using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gold_animation : MonoBehaviour
{
    public Image[] fruit = new Image[7];
    public RectTransform[] OBJfruit = new RectTransform[7];

    public Transform parent;
    public Transform Finish;

    public float speed = 3f;

    private List<GameObject> moveFruit = new List<GameObject>();
    private TotalScore totalScore;

    private bool isAnimationStarted = false;

    void Start()
    {
        totalScore = FindFirstObjectByType<TotalScore>();
        // for (int i = 0; i < fruit.Length; i++)
        // {
        //     cutString.Add(fruit[i].name.Substring(0, fruit[i].name.Length - 1));
        // }
    }

    void Update()
    {
        // MoveFruits();
        StartCoroutine(GoldAnimationCoroutine());
        if (totalScore.finishGame && !isAnimationStarted)
        {
            createFruit();
            isAnimationStarted = true;
        }
        if (isAnimationStarted)
        {
            MoveFruits();
        }
    }

    private void createFruit()//생성까지끝
    {
        for (int i = 0; i < fruit.Length; i++)
        {
            int count = 5;
            // GameManager.Instance.CountFruitz[fruit[i].name];
            Debug.Log(count);

            for (int j = 0; j < count; j++)
            {
                GameObject gbj = Instantiate(fruit[i].gameObject,OBJfruit[i].anchoredPosition,quaternion.identity,parent);
                RectTransform rt = gbj.GetComponent<RectTransform>();
                rt.anchoredPosition = OBJfruit[i].GetComponent<RectTransform>().anchoredPosition;
                moveFruit.Add(gbj);
                
            }
        }
    }

    private void MoveFruits()
    {
        List<GameObject> toRemove = new List<GameObject>();

        foreach (GameObject f in moveFruit)
        {
            if (f == null) continue;

            RectTransform rt = f.GetComponent<RectTransform>();
            RectTransform target = Finish.GetComponent<RectTransform>();

            
            Vector2 worldPos = Vector2.MoveTowards(rt.position, target.position, speed);
            rt.position = worldPos;

            if (Vector2.Distance(rt.position, target.position) < 0.1f)
            {
                Destroy(f);
                toRemove.Add(f);
            }
        }

        foreach (GameObject f in toRemove)
            moveFruit.Remove(f);

        isAnimationStarted = false;
    }



    private IEnumerator GoldAnimationCoroutine()
    {
        yield return new WaitForSeconds(8f);
        
    }
}
