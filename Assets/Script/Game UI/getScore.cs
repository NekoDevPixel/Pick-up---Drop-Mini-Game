using TMPro;
using UnityEngine;

public class getScore : MonoBehaviour
{
    public TextMeshProUGUI  getscore;
    private Vector3 startPos;
    private Player_Move player;

    public float moveSpeed = 5f;
    public float stopYPos = 0f;
    public float destroyTime = 1f;

    private float animationTimer;
    private bool isAnimating = false; // 애니메이션이 진행 중인지 확인하는 플래그


    void Start()
    {
        getscore.gameObject.SetActive(false);
        startPos = getscore.gameObject.transform.localPosition;
        player = FindFirstObjectByType<Player_Move>();
    }

    void LateUpdate()
    {
        transform.position = player.transform.position;
        if (isAnimating)
        {
            getscore.gameObject.transform.localPosition += Vector3.up * moveSpeed * Time.deltaTime; ;
            animationTimer += Time.deltaTime;

            Color newColor = getscore.color;
            newColor.a = 1 - (animationTimer / destroyTime);//숫자가 희미해짐
            getscore.color = newColor;

            // 애니메이션이 끝나면 리셋합니다.
            if (animationTimer >= destroyTime)
            {
                ResetAnimation();
            }
        }
    }

    public void lookscore(int sc)
    {
        ResetAnimation();

        // 텍스트를 활성화하고 점수를 설정합니다.
        if (sc > 0)
        {
            getscore.text = $"+{sc}";
        }
        else
        {
            getscore.text = $"{sc}";
        }
        
        getscore.gameObject.SetActive(true);
        isAnimating = true;
    }

    private void ResetAnimation()
    {
        isAnimating = false;
        getscore.gameObject.SetActive(false);
        getscore.gameObject.transform.localPosition = startPos;
        // 텍스트 색상을 다시 불투명하게 만듭니다.
        getscore.color = new Color(getscore.color.r, getscore.color.g, getscore.color.b, 1);
        animationTimer = 0f;
    }
}
