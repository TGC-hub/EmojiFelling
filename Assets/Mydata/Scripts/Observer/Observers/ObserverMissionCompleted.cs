using System.Collections.Generic;

public class ObserverMissionCompleted : MyMonoBehavior
{
    private static ObserverMissionCompleted instance;
    public static ObserverMissionCompleted Instance => instance;

    private List<IMissionCompleted> observers = new List<IMissionCompleted>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IMissionCompleted observerShot) 
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IMissionCompleted observerShot) 
    {
        observers.Remove(observerShot);
    }

    public void CompletedMission()
    {
        foreach(IMissionCompleted observer in observers) 
        {
            observer.DownPositon();
        }
    }
    public void NextMission()
    {
        foreach (IMissionCompleted observer in observers)
        {
            observer.NextMission();
        }
    }
}
