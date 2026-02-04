using UnityEngine;

public class CameraSizeFix : MonoBehaviour
{
    public float baseWidth = 9f;   // 기준 가로 비율
    public float baseHeight = 16f; // 기준 세로 비율
    public float baseSize = 5f;    // 현재 쓰는 Orthographic Size

    void Start()
    {
        float screenRatio = (float)Screen.width / Screen.height;
        float targetRatio = baseWidth / baseHeight;

        Camera cam = GetComponent<Camera>();

        if (screenRatio >= targetRatio)
        {
            cam.orthographicSize = baseSize;
        }
        else
        {
            float difference = targetRatio / screenRatio;
            cam.orthographicSize = baseSize * difference;
        }
    }
}
