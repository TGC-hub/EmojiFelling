public class SingleEffectSpawner : Spawner
{
    private static SingleEffectSpawner instance;
    public static SingleEffectSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
}
