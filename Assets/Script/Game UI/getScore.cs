using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class getScore : MonoBehaviour
{
    public TextMeshProUGUI  getscore;
    private Vector3 startPos;
    private Player_Move player;

    public float moveSpeed = 5f;
    public float stopYPos = 0f;

    void Start()
    {
        getscore.text = "";
        startPos = getscore.gameObject.transform.position;
        player = FindFirstObjectByType<Player_Move>();
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.position = player.transform.position;
        
    }

    public void lookscore(int sc)
    {
        getscore.text = $"{sc}";   
    }

    // void moveGet()
    // {
    //     if (getfruit)
    //     {
    //         getscore.gameObject.transform.position = new Vector2(0, Time.deltaTime * moveSpeed);
    //     }
    //     else
    //     {

    //     }
    // }
}
