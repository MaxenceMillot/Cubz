using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
}
