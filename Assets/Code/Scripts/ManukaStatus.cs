using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manuki.Character.Status;

public class ManukaStatus : CharacterStatus
{
    [Header("Status")]
    public float maxSpeed = 2.0f;
    public float damage = 5.0f;

    public EndPanel panel;

    private void Update()
    {
        Death();
    }

    public override void Death()
    {
        if (currentHP <= 0)
        {
            if (playDeathAnimation)
            {
                if (hasAnimator)
                {
                    animator.SetBool("fainted", true);

                    panel.ManukaFainted();
                    panel.gameObject.SetActive(true);
                }
            }
        }
    }
}
