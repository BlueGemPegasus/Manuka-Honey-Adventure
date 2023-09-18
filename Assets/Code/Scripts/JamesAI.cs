using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manuki.Character;

public class JamesAI : MonoBehaviour
{
    public Transform Manuka;
    public bool specialActivate = false;
    
    public JamesSkillCutscene cs;
    public GameObject prefabHorizontalFire;
    public GameObject prefabVerticalFire;
    public GameObject prefabProtectionCircle;
    public GameObject prefabRainFire;

    public Transform[] protectionCircle;
    public float skillCoolDownTime = 5f;

    private float skillCoolDownTimer = 10f;
    private bool skillcountdown = false;


    public BossJames jamesstats;

    private void Start()
    {
        jamesstats = GetComponent<BossJames>();

    }

    private void Update()
    {
        if (specialActivate)
        {
            if (skillcountdown)
            {
                skillCoolDownTimer -= Time.deltaTime;
            }

            if (skillCoolDownTimer <= 0)
            {
                skillcountdown = false;
                skillCoolDownTimer = skillCoolDownTime;
                UseSkill();
            }
        }
        else
            SpecialAttack();
    }

    private void SpecialAttack()
    {
        if (jamesstats.currentHP <= (jamesstats.MaxHP / 2))
        {
            specialActivate = true;
            transform.position = new Vector3(0, 6, 0);
            UseSkill();
        }
    }

    private void UseSkill()
    {
        cs.background.SetActive(true);
    }

    public void ChooseSkillFormula()
    {
        int SkillChoice = Random.Range(0, 2);
        switch (SkillChoice)
        {
            case 0:
                HorizontalFire();
                skillcountdown = true;
                break;
            case 1:
                VerticalFire();
                skillcountdown = true;
                break;
            case 2:
                RainFire();
                skillcountdown = true;
                break;
            default:
                return;
        }

    }

    private void HorizontalFire()
    {
        Vector3 ManukaPosition = new Vector3(0, Manuka.position.y, 0);
        Instantiate(prefabHorizontalFire, ManukaPosition, Quaternion.identity);
    }

    private void VerticalFire()
    {
        Vector3 ManukaPosition = new Vector3(Manuka.position.x, 0, 0);
        Instantiate(prefabVerticalFire, ManukaPosition, Quaternion.identity);
    }

    private void RainFire()
    {
        int randomLocationSpawn = Random.Range(0, 4); // 5 location for the circle to spawn
        Instantiate(prefabProtectionCircle, protectionCircle[randomLocationSpawn].position, Quaternion.identity);
        Instantiate(prefabRainFire, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
