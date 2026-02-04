using UnityEngine;
using UnityEngine.InputSystem; // Input System 네임스페이스

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;
    private Animator animator;

    public float speed = 5f;

    // 모바일 터치 입력을 위한 변수
    private bool isTouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 1. 모바일 터치 입력 처리
        HandleTouchInput();

        // 2. 애니메이션 처리
        float h = move.x;
        animator.SetFloat("Move", Mathf.Abs(h));

        // 3. 캐릭터 방향 회전 (스케일 조정)
        if (move.x > 0f) // 오른쪽
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move.x < 0f) // 왼쪽
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        // Unity 6.0 이상에서 사용하는 linearVelocity
        rb.linearVelocity = new Vector2(move.x * speed, rb.linearVelocity.y);
    }

    // 키보드/게임패드 입력 (PC 에디터 테스트용 유지)
    void OnMove(InputValue value)
    {
        // 터치 중이 아닐 때만 키보드 입력을 받음 (충돌 방지)
        if (!isTouching)
        {
            move = value.Get<Vector2>();
        }
    }

    // 모바일 터치 로직 함수
    void HandleTouchInput()
    {
        // 현재 터치스크린 장치가 없으면 리턴 (PC에서 에러 방지)
        if (Touchscreen.current == null) return;

        // 화면이 눌렸는지 확인
        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            isTouching = true;

            // 터치한 위치 가져오기
            Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();

            // 화면 너비의 절반 구하기
            float halfScreenWidth = Screen.width / 2f;

            // 터치 위치가 화면 중앙보다 작으면 왼쪽, 크면 오른쪽
            if (touchPos.x < halfScreenWidth)
            {
                move = new Vector2(-1, 0); // 왼쪽 이동
            }
            else
            {
                move = new Vector2(1, 0);  // 오른쪽 이동
            }
        }
        else
        {
            // 터치가 끝났을 때
            if (isTouching)
            {
                isTouching = false;
                move = Vector2.zero; // 이동 멈춤
            }
        }
    }
}