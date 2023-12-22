
public class DoubleEffectSpawner : Spawner
{
    private static DoubleEffectSpawner instance;
    public static DoubleEffectSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
}
