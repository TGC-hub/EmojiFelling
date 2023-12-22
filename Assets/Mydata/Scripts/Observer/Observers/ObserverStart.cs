using System.Collections;
using System.Collections.Generic;

public class ObserverStart : MyMonoBehavior
{
    private static ObserverStart instance;
    public static ObserverStart Instance => instance;

    private List<IStart> observers = new List<IStart>();

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public void AddObserver(IStart observerShot)
    {
        observers.Add(observerShot);
    }

    public void RemoveObserver(IStart observerShot)
    {
        observers.Remove(observerShot);
    }

    public void PlayerStartGame()
    {
        foreach (IStart observer in observers)
        {
            observer.OnStartting();
        }
    }

}
