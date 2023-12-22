using System.Collections.Generic;

public class ObserverShot : MyMonoBehavior
{
    private static ObserverShot instance;
    public static ObserverShot Instance => instance;

    private List<IShootting> observers = new List<IShootting>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IShootting observerShot) 
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IShootting observerShot) 
    {
        observers.Remove(observerShot);
    }

    public void PlayerStartShoot()
    {
        foreach(IShootting observer in observers) 
        {
            observer.StartShootArrow();
        }
    }

    public void PlayerFinishShoot()
    {
        foreach (IShootting observer in observers)
        {
            observer.FinishShootArrow();
        }
    }
}
