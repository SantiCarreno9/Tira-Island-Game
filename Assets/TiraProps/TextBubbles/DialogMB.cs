using System.Collections;
using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public float typingSpeed = 0.02f; // Adjust the typing speed as needed
    public string[] dialogues;

    public GameObject bubble;

    private int currentLine = 0;

    void Start()
    {
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in dialogues[currentLine].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
        }
    }

    void NextLine()
    {
        if (currentLine < dialogues.Length - 1)
        {
            currentLine++;
            textDisplay.text = ""; // Clear the text before typing the next line
            StartCoroutine(TypeText());
        }
        else
        {
            bubble.SetActive(false);
        }
    }
}
