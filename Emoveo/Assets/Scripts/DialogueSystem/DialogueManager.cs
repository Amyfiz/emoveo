using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public Queue<string> SentenceQueue;

    // Start is called before the first frame update
    void Start()
    {
        SentenceQueue = new Queue<string>();
    }
}
