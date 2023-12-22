using UnityEngine;

public class PlayerHomeAnim : MyMonoBehavior,IStart
{
    private Animator animator;

    private int runningHash;

    protected override void Start()
    {
        base.Start();
        ObserverStart.Instance.AddObserver(this);
        animator = transform.GetComponent<Animator>();
        runningHash = Animator.StringToHash("OnRunning");
    }

    protected virtual void Running() 
    {
        animator.SetBool(runningHash, true);
    }

    public void OnStartting()
    {
        Running();
    }
}
