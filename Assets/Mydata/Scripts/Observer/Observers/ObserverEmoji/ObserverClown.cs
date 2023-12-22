using System.Collections.Generic;
using UnityEngine;

public class ObserverClown : MyMonoBehavior
{
    private static ObserverClown instance;
    public static ObserverClown Instance => instance;

    private List<IEmojiClown> observers = new List<IEmojiClown>();
    public int Count => observers.Count;

    private Vector3 tagetPos;
    public Vector3 TagetPos => tagetPos;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    protected virtual void FixedUpdate()
    {
        if (observers.Count > 1) return;
        tagetPos = Vector3.zero;
    }
    public void AddObserver(IEmojiClown observerShot)
    {
        if (observers.Contains(observerShot) == true) return;
        observers.Add(observerShot);
    }

    public void RemoveObserver(IEmojiClown observerShot)
    {
        tagetPos = Vector3.zero;
        if (observers.Contains(observerShot) == false) return;
        observers.Remove(observerShot);
    }

    public virtual void OnActiveInterface()
    {
        if (observers.Count < 2) return;
        tagetPos = CalculateAveragePosition();
        foreach (IEmojiClown observer in observers)
        {
            observer.OnActiveEvent();
        }
    }

    public virtual void OffActiveInterface()
    {
        if (observers.Count > 1) return;
        foreach (IEmojiClown observer in observers)
        {
            observer.OffActiveEvent();
        }
    }

    public virtual Vector3 CalculateAveragePosition()
    {
        Vector3 sum = Vector3.zero;

        foreach (IEmojiClown observer in observers)
        {
            sum += observer.GetTransform().position;
        }

        return sum / observers.Count;
    }
    public virtual int GetCountInListName(string name1, string name2)
    {
        int sum = 0;
        foreach (IEmojiClown observer in observers)
        {
            if (observer.GetTransform().name.StartsWith(name1, System.StringComparison.OrdinalIgnoreCase)
               || observer.GetTransform().name.StartsWith(name2, System.StringComparison.OrdinalIgnoreCase))
            {
                sum++;
            }
        }
        return sum;
    }
}
