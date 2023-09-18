using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndPanel : MonoBehaviour
{
    public TextMeshProUGUI DescText;

    public void ManukaFainted()
    {
        DescText.text = "You have fainted and brought back to the castle by James.";
    }


    public void returntomainmenu()
    {
        SceneManager.LoadScene("PrototypeMainMenu");
    }
}
