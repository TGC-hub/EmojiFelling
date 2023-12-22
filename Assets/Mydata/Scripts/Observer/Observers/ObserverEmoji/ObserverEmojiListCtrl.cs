
using UnityEngine;

public class ObserverEmojiListCtrl : MyMonoBehavior
{
    private static ObserverEmojiListCtrl instance;
    public static ObserverEmojiListCtrl Instance => instance;

    Vector3 posTarget;
    public Vector3 PosTarget => posTarget;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }

    public virtual void AddObservers(float type, Transform obj)
    {
        this.RemoveObservers(obj);
        switch (type)
        {
            case 0:
                ObserverHappy.Instance.AddObserver(obj.GetComponent<IEmojiHappy>());
                break;
            case 1:
                ObserverAngry.Instance.AddObserver(obj.GetComponent<IEmojiAngry>());
                break;
            case 2: 
                ObserverCry.Instance.AddObserver(obj.GetComponent<IEmojiCry>());
                break;
            case 3:
                ObserverVomiting.Instance.AddObserver(obj.GetComponent<IEmojiVomiting>());
                break;
            case 4:
                ObserverClown.Instance.AddObserver(obj.GetComponent<IEmojiClown>());
                break;
            default:
                break;
        }
    }

    public virtual void RemoveObservers(Transform obj) 
    {
        ObserverHappy.Instance.RemoveObserver(obj.GetComponent<IEmojiHappy>());
        ObserverCry.Instance.RemoveObserver(obj.GetComponent<IEmojiCry>());
        ObserverAngry.Instance.RemoveObserver(obj.GetComponent<IEmojiAngry>());
        ObserverVomiting.Instance.RemoveObserver(obj.GetComponent<IEmojiVomiting>());
        ObserverClown.Instance.RemoveObserver(obj.GetComponent<IEmojiClown>());
    }

    public virtual void OnActiveAll(float type)
    {
        switch (type)
        {
            case 0:
                ObserverHappy.Instance.OnActiveInterface();
                break;
            case 1:
                ObserverAngry.Instance.OnActiveInterface();
                break;
            case 2:
                ObserverCry.Instance.OnActiveInterface();
                break;
            case 3:
                ObserverVomiting.Instance.OnActiveInterface();
                break;
            case 4:
                ObserverClown.Instance.OnActiveInterface();
                break;
            default:
                break;
        }
    }

    public virtual void OffActiveAll(float type)
    {
        switch (type)
        {
            case 0:
                ObserverHappy.Instance.OffActiveInterface();
                break;
            case 1:
                ObserverAngry.Instance.OffActiveInterface();
                break;
            case 2:
                ObserverCry.Instance.OffActiveInterface();
                break;
            case 3:
                ObserverVomiting.Instance.OffActiveInterface();
                break;
            case 4:
                ObserverClown.Instance.OffActiveInterface();
                break;
            default:
                break;
        }
    }

    public virtual void SetPosTarget(float typeEmoji)
    {
        switch (typeEmoji)
        {
            case 0:
                posTarget = Vector3.zero;
                posTarget = ObserverHappy.Instance.TagetPos;
                break;
            case 1:
                posTarget = Vector3.zero;
                posTarget = ObserverAngry.Instance.TagetPos;
                break;
            case 2:
                posTarget = Vector3.zero;
                posTarget = ObserverCry.Instance.TagetPos;
                break;
            case 3:
                posTarget = Vector3.zero;
                posTarget = ObserverVomiting.Instance.TagetPos;
                break;
            case 4:
                posTarget = Vector3.zero;
                posTarget = ObserverClown.Instance.TagetPos;
                break;
            default:
                posTarget = Vector3.zero;
                break;
        }
    }

}
