using System.Collections;
using UnityEngine;

public class UITaskCtrl : MyMonoBehavior
{
    [SerializeField] protected TaskListEmoji taskListEmoji;
    [SerializeField] protected TaskListHumanLeft humanLeft;
    [SerializeField] private TaskListHumanRight humanRight;

    protected bool onFinishMission = true;
    protected bool onNextMission = true;
    protected int numberOfMission = 2;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadListEmoji();
        LoadHumanLeft();
        LoadHumanRight();
    }

    protected virtual void LoadListEmoji()
    {
        if (taskListEmoji != null) return;
        taskListEmoji = transform.GetComponentInChildren<TaskListEmoji>();
    }

    protected virtual void LoadHumanLeft()
    {
        if (humanLeft != null) return;
        humanLeft = transform.GetComponentInChildren<TaskListHumanLeft>();
    }

    protected virtual void LoadHumanRight()
    {
        if (humanRight != null) return;
        humanRight = transform.GetComponentInChildren<TaskListHumanRight>();
    }

    protected virtual void FixedUpdate()
    {
        FollowResultMission();
    }
    protected virtual void FollowResultMission()
    {
        switch (taskListEmoji.MissionValue) 
        {
            case 0:
                if (ObserverHappy.Instance.GetCountInListName(humanLeft.ObjectRandom.name, humanRight.ObjectRandom.name) < 2) return;
                NextMission();
                break;
            case 1:
                if (ObserverAngry.Instance.GetCountInListName(humanLeft.ObjectRandom.name, humanRight.ObjectRandom.name) < 2) return;
                NextMission();
                break;
            case 2:
                if (ObserverCry.Instance.GetCountInListName(humanLeft.ObjectRandom.name, humanRight.ObjectRandom.name) < 2) return;
                NextMission();
                break;
            case 3:
                if (ObserverVomiting.Instance.GetCountInListName(humanLeft.ObjectRandom.name, humanRight.ObjectRandom.name) < 2) return;
                NextMission();
                break;
            case 4:
                if (ObserverClown.Instance.GetCountInListName(humanLeft.ObjectRandom.name, humanRight.ObjectRandom.name) < 2) return;
                NextMission();
                break;
        }
    }

    protected virtual void NextMission()
    {
        if (onNextMission == false) return;
        onNextMission = false;
        StartCoroutine(WaitForNextMission());
    }

    IEnumerator WaitForNextMission()
    {
        yield return new WaitForSeconds(5.0f);
        if (numberOfMission > 0)
        {
            ObserverMissionCompleted.Instance.NextMission();
            numberOfMission--;
            onNextMission = true;
        }
        else
        {
            FinishMission();
        }

    }

    public virtual void FinishMission()
    {
        if (onFinishMission == false) return;
        onFinishMission = false;
        StartCoroutine(WaitingForComplete());
    }

    IEnumerator WaitingForComplete()
    {
        yield return new WaitForSeconds(5.0f);
        ObserverMissionCompleted.Instance.CompletedMission();
        onFinishMission = true;
        onNextMission = true;
        numberOfMission = 2;
    }
}
