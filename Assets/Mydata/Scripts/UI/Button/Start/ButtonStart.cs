
using UnityEngine;

public class ButtonStart : BaseButton
{
    protected override void OnClick()
    {
        ObserverStart.Instance.PlayerStartGame();
    }
}
