using UnityEngine;

public class HumanController : MyMonoBehavior
{
    [SerializeField] protected HumanMoveDefault humanMoveDefault;
    public HumanMoveDefault HumanMoveDefault => humanMoveDefault;

    [SerializeField] protected HumanMoveToEvent humanMoveToEvent;
    public HumanMoveToEvent HumanMoveToEvent => humanMoveToEvent;

    [SerializeField] protected HumanEventChecker humanEventChecker;
    public HumanEventChecker HumanEventChecker => humanEventChecker;

    [SerializeField] protected IconCtrl iconCtrl;
    public IconCtrl IconCtrl => iconCtrl;

    [SerializeField] protected SingleEffectCtrl singleEffectCtrl;
    public SingleEffectCtrl SingleEffectCtrl => singleEffectCtrl;

    [SerializeField] protected DoubleEffectCtrl doubleEffectCtrl;
    public DoubleEffectCtrl DoubleEffectCtrl => doubleEffectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHumanMoveDefault();
        LoadHumanToEvent();
        LoadHumanEventChecker();
        LoadIconCtrl();
        LoadEffectCtrl();
        LoadDoubleEffect();
    }
    protected virtual void LoadDoubleEffect()
    {
        if (doubleEffectCtrl != null) return;
        doubleEffectCtrl = transform.GetComponentInChildren<DoubleEffectCtrl>();    
    }
    protected virtual void LoadEffectCtrl()
    {
        if (singleEffectCtrl != null) return;
        singleEffectCtrl = transform.GetComponentInChildren<SingleEffectCtrl>();
    }
    protected virtual void LoadIconCtrl()
    {
        if (iconCtrl != null) return;
        iconCtrl = transform.GetComponentInChildren<IconCtrl>();
    }

    protected virtual void LoadHumanEventChecker()
    {
        if (humanEventChecker != null) return;
        humanEventChecker = transform.GetComponentInChildren<HumanEventChecker>();
    }
    protected virtual void LoadHumanMoveDefault()
    {
        if (humanMoveDefault != null) return;
        humanMoveDefault = transform.GetComponent<HumanMoveDefault>();
    }

    protected virtual void LoadHumanToEvent()
    {
        if (humanMoveToEvent != null) return;
        humanMoveToEvent = transform.GetComponent<HumanMoveToEvent>();
    }


}
