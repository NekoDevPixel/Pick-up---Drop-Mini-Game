using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 0f;
        StartCoroutine(StartCountdown());
    }

    public TextMeshProUGUI countText;
    IEnumerator StartCountdown()
    {
        float countdown = 3f;
        gameObject.SetActive(true);

        while (countdown > 0)
        {
            countText.text = Mathf.Ceil(countdown).ToString();
            countdown -= Time.unscaledDeltaTime; // ⬅️ 실시간 사용
            yield return null; // 매 프레임마다 업데이트
        }

        Time.timeScale = 1f;
        gameObject.SetActive(false);
        // 카운트다운 끝나면 게임 시작
    }

}
