using UnityEngine;

public class FrameRateLimiter : MonoBehaviour
{
    void Start()
    {
        // FPS'yi 60 olarak sınırla
        Application.targetFrameRate = 60;
    }
    
}
