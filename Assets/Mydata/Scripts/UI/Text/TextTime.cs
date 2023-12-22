
using UnityEngine;

public class TextTime : BaseText, IStart, IMissionCompleted
{

    [SerializeField] protected float timeCountDown = 120.0f;

    [SerializeField] protected float timer = 0;

    protected bool onCountDown = true;

    protected override void Start()
    {
        base.Start();
        ObserverMissionCompleted.Instance.AddObserver(this);
    }
    private void ConvertSecondsToMinutesAndSeconds(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;

        this.text.SetText(minutes + ":" + seconds);
    }

    protected virtual void FixedUpdate()
    {
        if (onCountDown == false) return;
        this.timer += Time.fixedDeltaTime;
        float timeGame = timeCountDown - this.timer;
        ConvertSecondsToMinutesAndSeconds((int)timeGame);
        if (timeGame > 0) return;
        ObserverWinLose.Instance.PlayerLose();
        onCountDown = false;
    }

    public void OnStartting()
    {
        throw new System.NotImplementedException();
    }

    public void NextMission()
    {
    }

    public void DownPositon()
    {
        timer = 0;
    }
}
