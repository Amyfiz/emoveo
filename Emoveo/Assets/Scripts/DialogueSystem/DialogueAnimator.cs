using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueAnimator : MonoBehaviour
{
    //public bool destroyWhenActivated;
    //public int timeout;
    public DialogueController dialogueController;

    public Animator startAnimation;
    public DialogueManager dialogueManager;

    public Dialogue dialogue;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnimation.SetBool("IsOpen", true);
        dialogueManager.StartDialogue(dialogue);
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        startAnimation.SetBool("IsOpen", false);
        dialogueManager.EndDialogue();
        
        if (dialogueController.destroyWhenActivated)
        {
            Destroy(gameObject);
        }
    }
}
