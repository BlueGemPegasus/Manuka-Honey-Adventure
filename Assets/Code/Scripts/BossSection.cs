using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSection : MonoBehaviour
{
    public GameObject bubbleChat;

    private Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = new Vector3(0, 0, 0);
            collision.TryGetComponent(out animator);
            if (animator != null)
            {
                animator.SetTrigger("hurt");
            }
            bubbleChat.SetActive(true);
            Invoke("closeBubbleChat", 5f);
        }
    }

    private void closeBubbleChat()
    {
        bubbleChat.SetActive(false);
    }

}

