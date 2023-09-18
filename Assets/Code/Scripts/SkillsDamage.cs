using Manuki.Character.Status;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillsDamage : MonoBehaviour
{
    [Header("Skill Status")]
    public float damage = 5f;
   
    private string Player = "Player";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == Player)
        {
            CharacterStatus target = collision.gameObject.GetComponent<CharacterStatus>();
            if (target!=null)
            {
                target.DealDamage(damage);
            }
        }
    }

    public void DestroySkill()
    {
        Destroy(this.gameObject);
    }
}
