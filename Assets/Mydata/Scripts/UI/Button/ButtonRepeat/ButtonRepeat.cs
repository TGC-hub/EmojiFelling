using UnityEngine.SceneManagement;

public class ButtonRepeat : BaseButton
{
    protected override void OnClick()
    {
        SceneManager.LoadScene(1);
        //InputManager.Instance.lockInput = true;
    }
}
