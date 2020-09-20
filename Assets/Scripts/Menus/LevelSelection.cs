using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelection : MonoBehaviour
{
    int playerBestScore;
    private void Start()
    {
        playerBestScore = PlayerPrefs.GetInt(Constants.BEST_SCORE);
        if(playerBestScore>0)
            GetComponent<Text>().text = "Best : " + playerBestScore;
    }
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void SelectLevel(int level)
    {
        SceneManager.LoadScene(level);
    }
     public void SelectInfiniteMode()
    {
        SceneManager.LoadScene(9);
    }
}
