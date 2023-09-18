using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manuki.Character.Status;
using Manuki.Character.Claymore;

namespace Manuki.Character
{
    public class BossJames : CharacterStatus
    {
        [Header("Status")]
        public float maxSpeed = 4.0f;
        public float damage = 10.0f;

        public SpriteRenderer spriteRender;
        public CapsuleCollider2D body;

        public float Timer = 2.0f;
        public bool Countdown = false;

        public GameObject endpanel;

        private void Awake()
        {
            spriteRender = GetComponent<SpriteRenderer>();
            body = GetComponent<CapsuleCollider2D>();
        }
        private void Start()
        {
            currentHP = MaxHP;
            spriteRender = GetComponent<SpriteRenderer>();
            body = GetComponent<CapsuleCollider2D>();
        }

        private void Update()
        {
            if (Countdown)
            {
                Timer -= Time.deltaTime;
            }

            if (Timer <= 0)
            {
                Countdown = false;
                Timer = 2.0f;
                body.enabled = true;
            }

            Death();
        }

        public override void DealDamage(float damage)
        {
            currentHP -= damage;
            body.enabled = false;
            Countdown = true;
            StartCoroutine(BlinkingVisualEffect(1.0f));
        }

        public override void Death()
        {
            if (currentHP <= 0)
            {
                endpanel.SetActive(true);
                // Prompt an Ending or some sort
            }
        }

        IEnumerator BlinkingVisualEffect(float waitTime)
        {
            var endTime = Time.time + waitTime;
            while (Time.time<endTime)
            {
                spriteRender.enabled = false;
                yield return new WaitForSeconds(0.2f);
                spriteRender.enabled = true;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}