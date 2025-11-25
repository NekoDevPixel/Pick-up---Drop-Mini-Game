using System.Text.RegularExpressions;
using UnityEngine;

public class MatchUI : MonoBehaviour
{
    public GameObject matchUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        matchUI.SetActive(false);
    }

    public void openbtn()
    {
        matchUI.SetActive(true);
    }

    public void closebrn()
    {
        matchUI.SetActive(false);
    }
}
