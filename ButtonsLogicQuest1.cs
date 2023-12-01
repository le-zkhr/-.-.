//отвечает за логику нажатия кнопок
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsLogicQuest1 : MonoBehaviour
{
    public void RepeatQuest() => SceneManager.LoadScene(2);
    public void GoToMap() => SceneManager.LoadScene(0);
    public void LaucnhQuest1() => SceneManager.LoadScene(2);
    public void LaucnhQuest2() => SceneManager.LoadScene(3);
}
