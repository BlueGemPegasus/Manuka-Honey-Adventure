using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void QuitButton()
    {
        Application.Quit();
    }

    public void StartDemo()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
