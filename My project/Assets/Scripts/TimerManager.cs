using UnityEngine;

public class TimerManager : MonoBehaviour
{
    public static TimerManager instance;

    public float scene1Time = 0f;
    public float scene2Time = 0f;

    private float startTime;
    private bool isRunning = false;

    public int currentScene = 1;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartTimer()
    {
        isRunning = true;
        startTime = Time.time;
    }

    public void StopTimer()
    {
        if (isRunning)
        {
            float elapsed = Time.time - startTime;
            if (currentScene == 1)
                scene1Time = elapsed;
            else if (currentScene == 2)
                scene2Time = elapsed;

            isRunning = false;
        }
    }

    public void ResetAndStartTimerForScene2()
    {
        StopTimer();
        currentScene = 2;
        StartTimer();
    }

    public float GetCurrentTime()
    {
        return Time.time - startTime;
    }

    public float GetTotalTime()
    {
        return scene1Time + scene2Time;
    }
}