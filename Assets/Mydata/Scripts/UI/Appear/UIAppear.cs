using System.Collections;
using UnityEngine;

public class UIAppear : BaseAppear
{
    protected override void Start()
    {
        SetStartPos();
        StartCoroutine(WaitForSecond());
    }

    IEnumerator WaitForSecond()
    {
        yield return new WaitForSeconds(5f);
        Appear();
    }

    public override void Appear()
    {
        this.show = true;
    }

}
