using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class supply_gold : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    private void Start()
    {
        goldText.text = $"{GameData.Instance.gold}";
    }

    private void LateUpdate() {
        goldText.text = $"{GameData.Instance.gold}";
    }

    public void buyItem(int price)
    {
        if(GameData.Instance.gold != 0)
        {
            GameData.Instance.gold = GameData.Instance.gold - price;
        }
    }
}
