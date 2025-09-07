using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 move;
    private Animator animator;

    public float speed = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = move.x;
        // Debug.Log(h);
        animator.SetFloat("Move", Mathf.Abs(h));

        if (move.x == 1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(move.x == -1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(move.x*speed,rb.linearVelocity.y);
    }

    void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
        Debug.Log(move);
    }
}
