using System;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Text scoreBord;
    public Text TimeBord;
    public Slider slider;

    private float startTime;
    public float remain;

    void Start()
    {
        slider.value = 1;
        startTime = Time.time;
    }

    void Update()
    {
        scoreBord.text = $"{GameManager.Instance.Total_score}";

        float elapsed = Time.time - startTime; //현재 시간
        remain = GameManager.Instance.limtTime - elapsed; // 남은 시간
        slider.value = remain/GameManager.Instance.limtTime;

        if (remain < 0) remain = 0;

        int minutes = Mathf.FloorToInt(remain / 60f);   // 분 ex)119/60 = 1.9 0.9는 버리고 1만 사용
        int seconds = Mathf.FloorToInt(remain % 60f);   // 초 ex)119%60 = 59.xxx 0.xxx버리고 59만 사용

        TimeBord.text = $"{minutes:00} : {seconds:00}";
        //{0:00}<- 0번쨰 자리를 두자리 수로 설정 : {1:00} <- 1번쨰 자리를 두자리 수로 설정
        // $"{minutes:00} : {seconds:00}"; 이렇게 사용해도 가능
    }


}
