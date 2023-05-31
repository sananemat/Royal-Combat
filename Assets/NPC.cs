using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
    {
    public GameObject dialoguePanel;
    public GameObject continueButton;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public Joystick joystick;

    private bool isTyping;

    private void Start()
        {
        dialoguePanel.SetActive(false);
        }

    private void Update()
        {
        if ((joystick.Horizontal!=0||joystick.Vertical!=0)||playerIsClose)
            {
            if (dialoguePanel.activeInHierarchy)
                {
                NextLine();
                }
            else
                {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
                }
            }
        if(dialogueText.text==dialogue[index])
            {
            continueButton.SetActive(true);
            }
        }

    public void ZeroText()
        {
        dialogueText.text="";
        index=0;
        dialoguePanel.SetActive(false);
        }


    //isTyping=true;
    //foreach (char letter in dialogue[index].ToCharArray())
    //    {
    //    dialogueText.text+=letter;
    //    yield return new WaitForSeconds(wordSpeed);
    //    }
    //isTyping=false;

    IEnumerator Typing()
        {
        isTyping=true;
        string currentDialogue = dialogue[index];
        dialogueText.text="";

        string[] dialogueLines = currentDialogue.Split('\n');
        for (int i = 0; i<dialogueLines.Length; i++)
            {
            dialogueText.text+=dialogueLines[i];

            if (i<dialogueLines.Length-1)
                {
                dialogueText.text+="\n"; // Append a newline character after each line (except the last line)
                }

            yield return new WaitForSeconds(wordSpeed);
            }

        isTyping=false;
        }







    private void OnTriggerEnter(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            playerIsClose=true;
            }
        }

    private void OnTriggerExit(Collider other)
        {
        if (other.CompareTag("Player"))
            {
            playerIsClose=false;
            ZeroText();
            }
        }

    public void NextLine()
        {
        continueButton.SetActive(false);
        if (isTyping)
            {
            dialogueText.text=dialogue[index];
            StopCoroutine(Typing());
            isTyping=false;
            }
        else
            {
            if (index<dialogue.Length-1)
                {
                index++;
                dialogueText.text="";
                StartCoroutine(Typing());
                }
            else
                {
                ZeroText();
                }
            }
        }
    }
