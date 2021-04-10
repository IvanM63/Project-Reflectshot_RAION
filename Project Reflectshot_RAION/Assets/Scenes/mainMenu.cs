using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void Tutorial() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playNow() {
        SceneManager.LoadScene("PlayNow");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
