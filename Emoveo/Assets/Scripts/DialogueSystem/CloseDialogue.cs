using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueSystem;

public class CloseDialogue : MonoBehaviour
{
    //public Animator closeDialogue;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        //.SetBool(AnimatorConstants.IsOpen, false);
    
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
