using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Manuki.Input;
using Manuki.Character;

public class DemoCutscene : MonoBehaviour
{
    public PlayerController player;

    public GameObject bubbleChat;
    public GameObject nextBubble;
    public Button nextButton;
    public TextMeshProUGUI text;
    public TextMeshProUGUI textButton;

    public BossJames james;

    private Action button;

    private float Timer;
    private bool Countdown = false;
    private int counter = 0;

    private void Start()
    {
        text.text = "You'll regret that you have defy me!";
        nextButton.onClick.AddListener(next);

        Timer = 5;

        player.enableAttack = false;
        player.enableMove = false;

        bubbleChat.SetActive(true);
        nextBubble.SetActive(true);
    
    }

    private void Update()
    {
        if (Countdown == true)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            Countdown = false;
            Timer = 8;
            counter++;
        }


        if (counter == 1)
        {
            text.text = "Even though you are not a real bee that mutated, I will catch you alive!";
            Countdown = true;
        }

        if (counter == 2)
        {
            text.text = "Don't you struggle! I will make you faint easily!";
            Countdown = true;
        }

        if (counter == 3)
        {
            text.text = "Where do you think you're going!?";
            bubbleChat.SetActive(false);
            nextBubble.SetActive(false);
            player.enableAttack = true;
            player.enableMove = true;
            james.currentHP = 50;
            counter++;
        }
    }

    public void next()
    {
        counter += 1;
        Timer = 5;
        Countdown = true;
        textButton.text = "Skip";
        nextButton.onClick.RemoveListener(next);
        nextButton.onClick.AddListener(skip);
    }

    public void skip()
    {
        counter = 3;
        bubbleChat.SetActive(false);
        nextBubble.SetActive(false);
    }
    

}
