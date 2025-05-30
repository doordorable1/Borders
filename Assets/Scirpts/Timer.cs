using UnityEngine;

public class Timer : MonoBehaviour
{
    private float elapsedTime = 0f;
    private bool isRunning = false;

    void Start()
    {
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            elapsedTime += Time.deltaTime;
        }
    }

    public float GetElapsedTime()
    {
        return elapsedTime;
    }
}
