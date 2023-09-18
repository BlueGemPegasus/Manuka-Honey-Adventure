using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Manuki.Character.Status
{
    public class CharacterStatus : MonoBehaviour
    {
        [Header("Status")]
        public int MaxHP = 50;
        public bool playDeathAnimation = false;

        public float currentHP;

        public Animator animator;
        public bool hasAnimator = false;



        private void Awake()
        {
            hasAnimator = TryGetComponent(out animator);
        }

        private void Start()
        {
            currentHP = MaxHP;
        }

        private void Update()
        {
            Death();
        }

        public virtual void DealDamage(float damage)
        {
            if (animator != null)
            {
                animator.SetTrigger("hurt");
            }

            currentHP -= damage;
        }

        public virtual void Death()
        {
            if (currentHP <= 0)
            {
                if (playDeathAnimation)
                {
                    if (hasAnimator)
                    {
                        animator.SetBool("fainted", true);
                        Invoke("DestroyObject", 3);
                    }
                }
                else
                    DestroyObject();
            }
        }

        private void DestroyObject()
        {
            Destroy(this.gameObject);
        }
    }
}

