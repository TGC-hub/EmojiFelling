public class DespawnSingleEffect : DespawnByTime
{
    public override void DespawnObject()
    {
        SingleEffectSpawner.Instance.Despawn(this.transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        delay = 7.0f;
    }
}
