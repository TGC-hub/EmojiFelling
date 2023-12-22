using UnityEngine;

public class EmojiSelecter : MyMonoBehavior
{
    private static EmojiSelecter instance;
    public static EmojiSelecter Instance => instance;

    private string emojiSelected = "";
    public string EmojiSelected => emojiSelected;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null) return;
        instance = this;
    }
    protected override void Start()
    {
        base.Start();
        if (PlayerPrefs.GetString("SelectEmoji") == null)
        {
            PlayerPrefs.SetString("SelectEmoji", "EmojiHappy");
        }
    }

    protected virtual void Update() 
    {
        emojiSelected = PlayerPrefs.GetString("SelectEmoji");
    }
}
