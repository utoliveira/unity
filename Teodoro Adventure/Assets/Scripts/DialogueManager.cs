using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text speakerText;
    public Text dialogueText;
     
    private Queue<string> sentences;

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        speakerText.text = dialogue.speaker;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
            sentences.Enqueue(sentence);

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = sentences.Dequeue();

    }

    public void DisplayNextSentenceLetterByLetter()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        StopAllCoroutines(); // If there's a coroutine, stop it. Better would be save the coroutine and then stop it
        StartCoroutine(sentences.Dequeue());
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }

    }

    public void EndDialogue()
    {
        Debug.Log("End of conversation");   
    }

}
