using UnityEngine;

public class HumanMoveToEvent : MyMonoBehavior, IEmojiCry, IEmojiHappy,IEmojiAngry,IEmojiClown,IEmojiVomiting
{
    [SerializeField] private bool onMoveToEvent = false;
    public bool OnMoveToEvent => onMoveToEvent;

    [SerializeField] private float distance = 99.0f;
    public float Distance => distance;

    [SerializeField] private float moveSpeedToTarget = 0.0f;
    public float MoveSpeedToTarget => moveSpeedToTarget;

    [SerializeField] protected HumanController controller;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }
    protected virtual void LoadCtrl()
    {
        if (controller != null) return;
        controller = transform.GetComponent<HumanController>();
    }
    protected virtual void FixedUpdate()
    {
        SetMoveToTarget();

        if (onMoveToEvent == true && controller.HumanEventChecker.TypeEmoji == 99)
        {
            onMoveToEvent = false;
        }
    }
    protected virtual void SetMoveToTarget()
    {
        if (onMoveToEvent == false) return;
        ObserverEmojiListCtrl.Instance.SetPosTarget(controller.HumanEventChecker.TypeEmoji);
        MoveToTarget(ObserverEmojiListCtrl.Instance.PosTarget);
    }

    public void OffActiveEvent()
    {
        onMoveToEvent = false;
    }

    public void OnActiveEvent()
    {
        onMoveToEvent = true;
    }

    protected virtual void MoveToTarget(Vector3 transformtarget)
    {
        if(transformtarget == Vector3.zero) return;
        LookAtTarget(transformtarget);
        distance = Vector3.Distance(this.transform.position, transformtarget);
        if (distance <= 1.0f) { this.moveSpeedToTarget = 0.0f; }
        else
        {
            this.moveSpeedToTarget = 1.0f;
            transform.Translate(Vector3.forward * moveSpeedToTarget * Time.fixedDeltaTime);
        }
    }

    protected virtual void LookAtTarget(Vector3 target)
    {
        transform.LookAt(new Vector3(target.x, transform.position.y, target.z));
    }

    public Transform GetTransform()
    {
        return this.transform;
    }
}
