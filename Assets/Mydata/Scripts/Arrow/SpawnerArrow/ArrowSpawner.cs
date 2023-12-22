public class ArrowSpawner : Spawner
{
    private static ArrowSpawner instance;
    public static ArrowSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
}
