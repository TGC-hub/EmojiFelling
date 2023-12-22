using System.Collections.Generic;
using UnityEngine;

public class RandomTask : MyMonoBehavior, IMissionCompleted
{
    [SerializeField] protected List<Transform> taskList;
    [SerializeField] protected Transform objectRandom;
    public Transform ObjectRandom => objectRandom;
    [SerializeField] protected int missionValue = 99;
    public int MissionValue => missionValue;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPrefabs();
    }

    protected virtual void LoadPrefabs()
    {
        if (this.taskList.Count > 0) { return; }
        else
        {
            foreach (Transform prefab in transform)
            {
                this.taskList.Add(prefab);
            }
            this.HidePrefabs();
        }

    }

    protected virtual void HidePrefabs()
    {
        foreach (Transform prefab in this.taskList)
        {
            prefab.gameObject.SetActive(false);
        }
    }


    protected override void Start()
    {
        base.Start();
        SetMissionValue();
        ObserverMissionCompleted.Instance.AddObserver(this);
    }


    public virtual Transform RandomPrefab()
    {
        int rand = Random.Range(0, this.taskList.Count);
        return this.taskList[rand];
    }

    protected virtual void ResetMissionValue()
    {
        if (objectRandom == null) return;
        objectRandom.gameObject.SetActive(false);
        objectRandom = null;
    }

    public void DownPositon()
    {
        SetMissionValue();
    }


    protected virtual void SetMissionValue()
    {
        ResetMissionValue();
        objectRandom = this.RandomPrefab();
        objectRandom.gameObject.SetActive(true);
        missionValue = taskList.IndexOf(objectRandom);
    }

    public void NextMission()
    {
        SetMissionValue();
    }
}
