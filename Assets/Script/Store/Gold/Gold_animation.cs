using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold_animation : MonoBehaviour
{
    public Image[] fruit = new Image[7];
    public Transform[] OBJfruit = new Transform[7];

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
    }

    private void createFruit()
    {
        for (int i = 0; i < fruit.Length; i++)
        {
            int count = 5;
            // GameManager.Instance.CountFruitz[fruit[i].name];
            Debug.Log(count);

            for (int j = 0; j < count; j++)
            {
                GameObject gbj = Instantiate(fruit[i].gameObject, parent);
                RectTransform rt = gbj.GetComponent<RectTransform>();
                rt.anchoredPosition = OBJfruit[i].GetComponent<RectTransform>().anchoredPosition;
                moveFruit.Add(gbj);
            }
            MoveFruits();
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

            // 부모가 다르면 월드 좌표 기준 이동 가능
            Vector3 worldPos = Vector3.MoveTowards(rt.position, target.position, speed * Time.deltaTime);
            rt.position = worldPos;

            if (Vector3.Distance(rt.position, target.position) < 0.1f)
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
        yield return new WaitForSeconds(1f);
        
    }
}
