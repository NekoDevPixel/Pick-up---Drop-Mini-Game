using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{
    public GameObject panel;
    public GameObject scoreImage;

    public TextMeshProUGUI TTscore;
    public float downspeed = 3f;
    private bool end = false;
    private float NTime;
    private float endTime;
    private bool moveimg = false;

    private IngameGold ingameGold;
    public bool finishGame = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endTime = GameManager.Instance.limtTime;
        panel.SetActive(false);
        scoreImage.SetActive(false);
        ingameGold = FindFirstObjectByType<IngameGold>();
    }

    // Update is called once per frame
    void Update()
    {
        endTime -= Time.deltaTime;
        NTime = endTime;
        if (NTime <= 0f && !end) // end 플래그로 한 번만 실행
        {
            end_Game();
        }
    }
    void LateUpdate()
    {
        if (moveimg)
        {
            animation_scoreBD();
            if (scoreImage.transform.localPosition.y < 0f)
            {
                moveimg = false;
            }
        }
    }

    public void end_Game()
    {
        end = true;
        GameManager.Instance.PauseGame();
        TTscore.text = $"{GameManager.Instance.Total_score}";
        ingameGold.plusFruitz_Gold();
        scoreManager();
        finishGame = true;
        if (end)
        {
            panel.SetActive(true);
            scoreImage.SetActive(true);
            moveimg = true;
            // animation_scoreBD();
        }
    }

    void animation_scoreBD()
    {
        scoreImage.transform.position += Vector3.down * downspeed * Time.unscaledDeltaTime;
    }

    void scoreManager()
    {
        GameData.Instance.yourScore.Add(GameManager.Instance.Total_score);
        GameData.Instance.Total_sum_score += GameManager.Instance.Total_score;
    }
}
