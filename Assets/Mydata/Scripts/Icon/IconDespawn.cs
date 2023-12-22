public class IconDespawn : DespawnByTime
{
    public override void DespawnObject()
    {
        IconSpawner.Instance.Despawn(this.transform.parent);
    }
}
