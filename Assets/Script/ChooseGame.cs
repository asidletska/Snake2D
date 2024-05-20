using UnityEngine.SceneManagement;
using UnityEngine;

public class ChooseGame : MonoBehaviour
{
    public void ChooseFirstGame()
    {
        SceneManager.LoadScene(2);
    }
    public void ChooseSecondGame()
    {
        SceneManager.LoadScene(3);
    }
}
