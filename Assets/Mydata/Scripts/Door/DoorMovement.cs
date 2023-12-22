public class DoorMovement : BaseMovement, IShootting
{
    protected override void LookAt()
    {
    }
    protected override void Start()
    {
        base.Start();
        ObserverShot.Instance.AddObserver(this);
    }
    public void FinishShootArrow()
    {
        speed = initialSpeed;
    }

    public void StartShootArrow()
    {
        speed = 0f;
    }
}
