using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DialogueSystem;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    public bool isDialogueOpen = false;

    public PlayerController playerController;

    public Animator animator;
    
    public Queue<string> SentenceQueue;

    public DialogueEntity currentDialogueEntity;

    private static DialogueManager instance;
    public static DialogueManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        SentenceQueue = new Queue<string>();
    }

    public void StartDialogue(DialogueEntity dialogueEntity)
    {
        isDialogueOpen = true;

        currentDialogueEntity = dialogueEntity;
        
        animator.SetBool(AnimatorConstants.IsOpen, true);
        nameText.text = currentDialogueEntity.name;

        if (!currentDialogueEntity.isAbleToWalk)
        {
            playerController.abilityToMove = false;
        }

        SentenceQueue.Clear();

        foreach (string sentence in currentDialogueEntity.sentences)
        {
            SentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (SentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = SentenceQueue.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(currentDialogueEntity.timeout);
        }
    }

    public void EndDialogue()
    {
        currentDialogueEntity = null;
        animator.SetBool(AnimatorConstants.IsOpen, false);
        playerController.abilityToMove = true;
        StopAllCoroutines();
        isDialogueOpen = false;
    }
}
