using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1"); // Load Level1 scene when the level 1 button is clicked.
    }

    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level2"); // Load Level2 scene when the level 2 button is clicked.
    }
    public void SelectLevel3()
    {
        SceneManager.LoadScene("Level3"); 
    }


}
