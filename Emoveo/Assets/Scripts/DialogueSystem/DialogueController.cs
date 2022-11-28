using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    //public DialogueAnimator dialogueAnimator;
    public PlayerController playerController;
    public DialogueManager dialogueManager;
    
    public bool destroyWhenActivated;
    public bool isAbleToMove;
    public float timeout;

    private void Start()
    {
        if (isAbleToMove)
        {
            playerController.abilityToMove = true;
        }
        else
        {
            playerController.abilityToMove = false;
        }

        dialogueManager.timeout = timeout;
    }
}
