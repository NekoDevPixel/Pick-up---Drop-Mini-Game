using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class MatchUI : MonoBehaviour
{
    public GameObject matchUI;
    public GameObject NameUI;
    public GameObject RoomUI;
    public TextMeshProUGUI statusText;
    public TMP_InputField inputField;

    public TextMeshProUGUI[] Name;

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

    public void nameInput()
    {
        PhotonNetwork.NickName = inputField.text;
        NameUI.SetActive(false);
        RoomUI.SetActive(true);
    }
}
