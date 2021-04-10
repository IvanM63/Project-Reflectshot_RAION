using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
    public void endMenu() {
        SceneManager.LoadScene("StartMenu");
    }
}
