using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Gold_animation : MonoBehaviour
{
    public GameObject[] obj = new GameObject[7];
    public RectTransform parent;
    public RectTransform[] fruitPos = new RectTransform[7];
    public RectTransform finishLine;
    private Image[][] nFruit = new Image[7][];

    private TotalScore totalScore;
    private float speed = 600f;

    private IngameGold ingameGold;
    private bool isAnimatingGold = false;
    private float targetGold = 0f;
    private float currentGold = 0f;

    void Start()
    {
        totalScore = FindFirstObjectByType<TotalScore>();
        ingameGold = FindFirstObjectByType<IngameGold>();
    }

    private void Update() {
        
        if (totalScore.finishGame)
        {
            targetGold = GameData.Instance.gold;
            Debug.Log($"목표 골드: {targetGold}");
            currentGold = 0f;
            creatfruit();
            StartCoroutine(MoveFruitsCoroutine()); // 코루틴 실행
            totalScore.finishGame = false;
        }
        if (isAnimatingGold)
        {
            AnimateGold();
        }
    }
    void creatfruit()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            int count = GameManager.Instance.CountFruitz[obj[i].name];
            nFruit[i] = new Image[count];

            for (int j = 0; j < count; j++)
            {
                GameObject gameobj = Instantiate(obj[i], parent);

                RectTransform rect = gameobj.GetComponent<RectTransform>();
                rect.anchoredPosition = fruitPos[i].anchoredPosition;

                nFruit[i][j] = gameobj.GetComponent<Image>();
            }
        }

    }
    
   IEnumerator MoveFruitsCoroutine()
    {
        
        for (int i = 0; i < obj.Length; i++)
        {
            if (nFruit[i] == null || nFruit[i].Length == 0)
            {
                continue; // 다음 과일로
            }
            
            for (int j = 0; j < nFruit[i].Length; j++)
            {
                Image fruit = nFruit[i][j];
                if (fruit == null) continue;

                RectTransform rect = fruit.GetComponent<RectTransform>();

                if (rect == null) continue;

                
                while (Vector2.Distance(rect.anchoredPosition, finishLine.anchoredPosition) > 0.1f)
                {
                    rect.anchoredPosition = Vector2.MoveTowards(
                        rect.anchoredPosition,
                        finishLine.anchoredPosition,
                        speed * Time.unscaledDeltaTime
                    );

                    yield return null; 
                }
               

                Destroy(fruit.gameObject);
                nFruit[i][j] = null;

                
                yield return null;
            }
            
            yield return new WaitForSecondsRealtime(0.2f);
        }
        isAnimatingGold = true;
    }

    private void AnimateGold()
    {

        if (currentGold < targetGold)
        {
            
            currentGold += Time.unscaledDeltaTime * targetGold * 2f; // 속도: targetGold의 2배
            
            if (currentGold > targetGold)
            {
                currentGold = targetGold;
            }
            
            ingameGold.goldtext.text = $"{(int)currentGold}";
        }
        else
        {
            currentGold = targetGold;
            ingameGold.goldtext.text = $"{(int)targetGold}";
            isAnimatingGold = false;
        }
        
    }
}
