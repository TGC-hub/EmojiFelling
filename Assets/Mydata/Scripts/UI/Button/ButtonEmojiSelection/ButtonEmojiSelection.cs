using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEmojiSelection : BaseButton
{
    [SerializeField] protected string emojiName;
    protected override void Start()
    {
        base.Start();
        this.emojiName = this.transform.gameObject.name;
    }
    protected override void OnClick()
    {
        PlayerPrefs.SetString("SelectEmoji", emojiName);
    }

}
