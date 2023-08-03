using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelSelectionPanel; // Reference to the panel containing level selection buttons.

    public void PlayGame()
    {
        // Show the level selection panel and hide the main menu buttons.
        levelSelectionPanel.SetActive(true);
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
