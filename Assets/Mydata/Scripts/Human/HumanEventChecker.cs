using System.Collections;
using UnityEngine;

public class HumanEventChecker : MyMonoBehavior
{
    [SerializeField] private float typeEmoji = 99.0f;
    public float TypeEmoji => typeEmoji;

    protected bool onActiveEvent = false;
    public bool OnActiveEvent => onActiveEvent;

    protected bool onWaiting = false;

    protected HumanController controller;

    [SerializeField] protected float delay = 7f;

    [SerializeField] protected float timer = 0;
    public float Timer => timer;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadCtrl();
    }

    protected virtual void LoadCtrl()
    {
        if (controller != null) return;
        controller = transform.parent.GetComponent<HumanController>();
    }

    public void ChangeTypeEmoji(string type)
    {
        switch (type)
        {
            case "EmojiHappy":
                typeEmoji = 0;
                break;
            case "EmojiAngry":
                typeEmoji = 1;
                break;
            case "EmojiCry":
                typeEmoji = 2;
                break;
            case "EmojiVomiting":
                typeEmoji = 3;
                break;
            case "EmojiClown":
                typeEmoji = 4;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Arrow"))
        {
            onActiveEvent = true;
            onWaiting = true;
            ChangeTypeEmoji(EmojiSelecter.Instance.EmojiSelected);
            ObserverEmojiListCtrl.Instance.AddObservers(typeEmoji, transform.parent);
            ObserverEmojiListCtrl.Instance.OnActiveAll(typeEmoji);
            ArrowSpawner.Instance.Despawn(other.transform);
            controller.IconCtrl.SpawnIconEmoji(typeEmoji);
            controller.SingleEffectCtrl.SpawnEffect(typeEmoji);
            controller.DoubleEffectCtrl.DespawnEffect();
            timer = 0;
        }
    }

    protected virtual void FixedUpdate()
    {
        if (controller.HumanMoveToEvent.OnMoveToEvent == false)
        {
            if (onWaiting == false) return;
            ActiveSingle();
        }
        else
        {
            ActiveDouble();
        }
        
    }

    protected virtual void ActiveSingle()
    {
        if (this.CountDown() == false) return;
        if (onActiveEvent == false) return;
        OffSingleEvent();
    }


    protected virtual void OffSingleEvent()
    {
        ObserverEmojiListCtrl.Instance.OffActiveAll(typeEmoji);
        ObserverEmojiListCtrl.Instance.RemoveObservers(this.transform.parent);
        controller.IconCtrl.DespawnIconEmoji();
        controller.SingleEffectCtrl.DespawnEffect();
        typeEmoji = 99;
        onActiveEvent = false;
        onWaiting = false;
    }
    protected virtual void ActiveDouble()
    {
        if (onActiveEvent == true) { onActiveEvent = false; timer = 0; onWaiting = false; }
        if (controller.HumanMoveToEvent.Distance > 1) return;
        controller.DoubleEffectCtrl.SpawnDoubleEffect(typeEmoji, ObserverEmojiListCtrl.Instance.PosTarget);
        if (this.CountDown() == false) return;
        OffDoubleEvent();
    }

    protected virtual void OffDoubleEvent()
    {
        ObserverEmojiListCtrl.Instance.OffActiveAll(typeEmoji);
        ObserverEmojiListCtrl.Instance.RemoveObservers(this.transform.parent);
        controller.IconCtrl.DespawnIconEmoji();
        controller.SingleEffectCtrl.DespawnEffect();
        controller.DoubleEffectCtrl.DespawnEffect();
        typeEmoji = 99;
        timer = 0;
    }

    protected virtual bool CountDown()
    {
        this.timer += Time.fixedDeltaTime;
        if (this.timer > this.delay) return true;
        return false;
    }

}
