public class IconSpawner : Spawner
{
    private static IconSpawner instance;
    public static IconSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
}
