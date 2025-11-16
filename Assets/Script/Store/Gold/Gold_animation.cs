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
    private float speed = 500f;

    private IngameGold ingameGold;
    private bool isAnimatingGold = false;
    private float targetGold = 0f;
    private float currentGold = 0f;

    void Start()
    {
        totalScore = FindFirstObjectByType<TotalScore>();
        // finishLine.anchoredPosition = new Vector2(0, -34f);
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
        // if (totalScore.finishGame)
        // {
        //     finishLine.anchoredPosition = finishLine.anchoredPosition;
        //     creatfruit();
        //     endCreat = true;
        //     totalScore.finishGame = false;
        // }
        // if(endCreat)
        // {
        //     movefruit();
        // }

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
        // i = 과일 종류 (사과, 배, 바나나...)
        for (int i = 0; i < obj.Length; i++)
        {
            if (nFruit[i] == null || nFruit[i].Length == 0)
            {
                continue; // 다음 과일로
            }
            // j = 해당 과일의 클론 개수 (예: 사과 3개)
            for (int j = 0; j < nFruit[i].Length; j++)
            {
                Image fruit = nFruit[i][j];
                if (fruit == null) continue;

                RectTransform rect = fruit.GetComponent<RectTransform>();

                if (rect == null) continue;

                // ▼▼ 여기서 한 개만 이동! 끝나기 전까지 다음 과일 이동 금지 ▼▼
                while (Vector2.Distance(rect.anchoredPosition, finishLine.anchoredPosition) > 0.1f)
                {
                    rect.anchoredPosition = Vector2.MoveTowards(
                        rect.anchoredPosition,
                        finishLine.anchoredPosition,
                        speed * Time.unscaledDeltaTime
                    );

                    yield return null; // 한 프레임씩 이동
                }
                // ▲▲ "j번째 과일" 끝남 ▲▲

                Destroy(fruit.gameObject);
                nFruit[i][j] = null;

                // 약간 텀 주고 싶으면 추가
                // yield return new WaitForSeconds(0.1f);
                yield return null;
            }
            // ▼ 한 종류(사과) 끝나고 다음 종류(배)로 넘어감
            yield return new WaitForSecondsRealtime(0.2f);
        }
        isAnimatingGold = true;
    }

    private void AnimateGold()
    {

        if (currentGold < targetGold)
        {
            // 골드를 부드럽게 증가 (속도 조절 가능)
            currentGold += Time.unscaledDeltaTime * targetGold * 2f; // 속도: targetGold의 2배
            Debug.Log(currentGold);
            // 목표치를 넘지 않도록
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
