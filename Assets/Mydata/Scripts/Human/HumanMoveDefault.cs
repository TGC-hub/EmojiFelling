using UnityEngine;

public class HumanMoveDefault : MovementRandom {

    [SerializeField] protected HumanController humanController;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadHumanctrl();
    }

    protected virtual void LoadHumanctrl()
    {
        if (humanController != null) return;
        humanController = transform.GetComponent<HumanController>();
    }
    protected override void FixedUpdate()
    {
        if (humanController.HumanMoveToEvent.OnMoveToEvent == true || humanController.HumanEventChecker.OnActiveEvent == true) { this.moveSpeedRandom = 0;}
        else 
        {
            if (onStopMovement == true) return;
            moveSpeedRandom = initialSpeed;
            CheckRaycast();
            MoveRandom();
        }
    }

}
