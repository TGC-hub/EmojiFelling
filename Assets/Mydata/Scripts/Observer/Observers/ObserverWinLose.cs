using System.Collections.Generic;

public class ObserverWinLose : MyMonoBehavior
{
    private static ObserverWinLose instance;
    public static ObserverWinLose Instance => instance;

    private List<IWinLose> observers = new List<IWinLose>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IWinLose observerShot)
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IWinLose observerShot)
    {
        observers.Remove(observerShot);
    }

    public void PlayerWin()
    {
        foreach (IWinLose observer in observers)
        {
            observer.SendMessYouWin();
        }
    }

    public void PlayerLose()
    {
        foreach (IWinLose observer in observers)
        {
            observer.SendMessYouLoss();
        }
    }
}
