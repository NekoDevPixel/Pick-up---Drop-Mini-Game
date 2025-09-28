using UnityEngine;

public class IngamePause : MonoBehaviour
{
    public GameObject pauseIn;

    void Start()
    {
        pauseIn.gameObject.SetActive(false);
    }

    void LateUpdate()
    {

    }

    public void showboard()
    {
        pauseIn.gameObject.SetActive(true);
        PauseGame();
    }

    public void closeboard()
    {
        pauseIn.gameObject.SetActive(false);
        PlayGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }
    public void PlayGame()
    {
        Time.timeScale = 1f;
    }
}
