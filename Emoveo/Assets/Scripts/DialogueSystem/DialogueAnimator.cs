using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnimation;

    [FormerlySerializedAs("dialogue")] public DialogueEntity dialogueEntity;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnimation.SetBool(AnimatorConstants.IsOpen, true);
        DialogueManager.Instance.StartDialogue(dialogueEntity);
    }
    
    public void OnTriggerExit2D(Collider2D other)
    {
        startAnimation.SetBool(AnimatorConstants.IsOpen, false);

        if (DialogueManager.Instance.currentDialogueEntity != null)
        {
            var destroyWhenActivated = DialogueManager.Instance.currentDialogueEntity.destroyWhenActivated;
            
            DialogueManager.Instance.EndDialogue();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
        }
    }
}
