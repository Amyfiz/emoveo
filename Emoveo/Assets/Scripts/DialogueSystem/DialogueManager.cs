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

    //public int timeout;

    //public Animator animator;
    
    public Queue<string> SentenceQueue;

    // Start is called before the first frame update
    void Start()
    {
        SentenceQueue = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue, int timeout)
    {
        isDialogueOpen = true;
        nameText.text = dialogue.name;
        
        SentenceQueue.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            SentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence(timeout);
    }

    public void DisplayNextSentence(int timeout)
    {
        if (SentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = SentenceQueue.Dequeue();
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence, timeout));
    }

    IEnumerator TypeSentence(string sentence, int timeout)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
            Thread.Sleep(timeout);
        }
    }

    public void EndDialogue()
    {
        isDialogueOpen = false;
    }
}
