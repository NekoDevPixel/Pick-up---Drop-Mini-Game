using UnityEngine;

public class StoreUI : MonoBehaviour
{
    [Header("상점UI")]
    public GameObject Store;
    private bool checkbtn = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Store.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CloseST()
    {
        Store.SetActive(false);
    }
    
    public void ClickST()
    {
        Store.SetActive(true);
    }
}
