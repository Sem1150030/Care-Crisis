using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuManager : MonoBehaviour
{
    public void startLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
