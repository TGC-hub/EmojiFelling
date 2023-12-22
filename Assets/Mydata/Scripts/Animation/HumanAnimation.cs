using UnityEngine;

public class HumanAnimation : MyMonoBehavior
{
    [SerializeField] private Animator animator;
    protected int movementHash;
    protected int onTriggerHash;
    protected int typeEmojiHash;

    [SerializeField] protected HumanController humanCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHumanMovement();
        LoadAnimator();
    }

    protected virtual void LoadAnimator()
    {
        if (animator != null) return;
        animator = transform.GetComponent<Animator>();
    }

    protected virtual void LoadHumanMovement()
    {
        if (humanCtrl != null) return;
        humanCtrl = transform.parent.GetComponent<HumanController>();
    }

    protected override void Start()
    {
        base.Start();
        movementHash = Animator.StringToHash("MoveSpeed");
        onTriggerHash = Animator.StringToHash("OnTriggerArrow");
        typeEmojiHash = Animator.StringToHash("TypeEmoji");
    }

    protected virtual void Update()
    {
        OnAnimationMovement();
        OnTriggerArrow();
    }

    protected virtual void OnTriggerArrow()
    {
        if(humanCtrl.HumanMoveToEvent.OnMoveToEvent == true)
        {
            if(humanCtrl.HumanMoveToEvent.Distance <= 1.0f)
            {
                animator.SetBool(onTriggerHash, true);
                animator.SetFloat(typeEmojiHash, humanCtrl.HumanEventChecker.TypeEmoji);
            }
            else
            {
                animator.SetBool(onTriggerHash, false);
            }
        }
        else
        {
            animator.SetBool(onTriggerHash, false);
        }
    }

    protected virtual void OnAnimationMovement()
    {
        if(humanCtrl.HumanMoveToEvent.OnMoveToEvent == true) 
        {
            if(humanCtrl.HumanMoveToEvent.MoveSpeedToTarget == 0)
            {
                animator.SetFloat(movementHash, 0);
            }
            else
            {
                animator.SetFloat(movementHash, 1);
            }
        }
        else
        {
            if (humanCtrl.HumanMoveDefault.MoveSpeed == 0)
            {
                animator.SetFloat(movementHash, 0);
            }
            else
            {
                animator.SetFloat(movementHash, 1);
            }
        }

    
    }


}
