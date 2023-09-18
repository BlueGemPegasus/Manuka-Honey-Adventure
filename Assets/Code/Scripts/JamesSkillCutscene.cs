using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JamesSkillCutscene : MonoBehaviour
{
    public GameObject background;
    public JamesAI jamesai;

    public void CloseBackground()
    {
        background.SetActive(false);
        jamesai.ChooseSkillFormula();
    }
}
