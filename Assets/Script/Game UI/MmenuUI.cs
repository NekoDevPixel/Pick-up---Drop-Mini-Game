using UnityEngine;
using UnityEngine.SceneManagement;

public class MmenuUI : MonoBehaviour
{
    public void Startbtn()
    {
        SceneManager.LoadScene("InGame");
        GameManager.Instance.PauseGame();
    }
}
