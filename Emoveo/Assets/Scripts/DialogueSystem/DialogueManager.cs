using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    public bool isDialogueOpen = false;

    public PlayerController playerController;
    public bool destroyWhenActivated;
    public bool isAbleToWalk;
    public float timeout;

    public Animator animator;
    
    public Queue<string> SentenceQueue;

    // Start is called before the first frame update
    void Start()
    {
        SentenceQueue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogueOpen = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;

        if (!isAbleToWalk)
        {
            playerController.abilityToMove = false;
        }

        SentenceQueue.Clear();

        foreach (string sentence in dialogue.sentences)
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
            yield return new WaitForSeconds(timeout);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        playerController.abilityToMove = true;
        isDialogueOpen = false;
    }
}
