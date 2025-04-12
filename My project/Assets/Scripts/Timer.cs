using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerMinutes;
    public TextMeshProUGUI timerSeconds;
    public TextMeshProUGUI timerSeconds100;

    void Start()
    {
        TimerManager.instance.StartTimer();
    }

    void Update()
    {
        float currentTime = TimerManager.instance.GetCurrentTime();

        int minutesInt = (int)currentTime / 60;
        int secondsInt = (int)currentTime % 60;
        int seconds100Int = (int)((currentTime - (secondsInt + minutesInt * 60)) * 100);

        timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
        timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
        timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
    }
}
