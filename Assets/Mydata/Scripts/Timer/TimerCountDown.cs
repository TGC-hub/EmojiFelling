using UnityEngine;

public class TimerCountDown : MonoBehaviour
{
    private void Start()
    {
        ConvertSecondsToMinutesAndSeconds(145);
    }

    private void ConvertSecondsToMinutesAndSeconds(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        Debug.Log($"Thời gian: {minutes} phút {seconds} giây");
    }
}
