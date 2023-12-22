public class DespawnDoubleEffect : DespawnByTime
{
    public override void DespawnObject()
    {
        DoubleEffectSpawner.Instance.Despawn(this.transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        delay = 2.0f;
    }
}
