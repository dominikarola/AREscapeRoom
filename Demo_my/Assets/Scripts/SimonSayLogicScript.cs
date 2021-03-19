using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonSayLogicScript : MonoBehaviour
{
    [SerializeField]
    private List<KeypadButtonScript> buttons;

    [SerializeField]
    private int sizeOfGame = 4;

    public List<int> necessaryButtonInteraction = new List<int>();

    private int actualStep = 0;

    [SerializeField]
    private GameObject displayOnCorrectAnswer;


    [SerializeField]
    private float displayTime = 0.8f;
    [SerializeField]
    private float firstDelay = 1.5f;
    [SerializeField]
    private float betweenButtonDisplayDelay = 0.2f;


    private void Start()
    {
        displayOnCorrectAnswer.SetActive(false);
        addRandomButton();
    }

    private void Update()
    {
    }

    public bool gotAnswer() {
        return displayOnCorrectAnswer.activeInHierarchy == true;
    }

    private void addRandomButton() {
        int index = Random.Range(0, buttons.Count);
        necessaryButtonInteraction.Add(index);
    }

    public void buttonInteracted(KeypadButtonScript keypadButtonScript) {

        if (!gotAnswer())
        {
            if (keypadButtonScript == buttons[necessaryButtonInteraction[actualStep]])
            {
                // reached end
                if (actualStep >= sizeOfGame - 1)
                {
                    // PRINT ANSWER
                    displayOnCorrectAnswer.SetActive(true);
                }
                else
                {
                    if (actualStep >= necessaryButtonInteraction.Count - 1)
                    {
                        Debug.Log("Need more");

                        // more steps
                        addRandomButton();
                        runPresentation();
                        actualStep = 0;
                    }
                    else {
                        actualStep++;
                    }
                }
            }
            else
            {
                Debug.Log("Wrong! Resetting");

                actualStep = 0;
                // no, error, reset
                clearNecessaryButtons();
                wrongAnswerDisplay();
                addRandomButton();
                runPresentation();
            }
        }
        else {
            Debug.Log("Answer gotten");
        }
    }

    void wrongAnswerDisplay() {
        for (int i = 0; i < buttons.Count; i++)
        {
            StartCoroutine(showButton(buttons[i], 0.0f, displayTime/2.0f));
        }
    }

    private void clearNecessaryButtons() {
        necessaryButtonInteraction.Clear();
    }

    void runPresentation() {
        Debug.Log("presenting");
        float inTime = firstDelay;

        List<int> tmp = new List<int>(necessaryButtonInteraction);
        StartCoroutine(showButtons(tmp, inTime, displayTime));
    }

    IEnumerator showButton(KeypadButtonScript keyButton, float waitTime, float displayTime)
    {
        yield return new WaitForSeconds(waitTime);
        keyButton.displayPress(true);

        yield return new WaitForSeconds(displayTime);
        keyButton.displayPress(false);
    }

    IEnumerator showButtons(List<int> keyButtonIndex, float waitTime, float displayTime)
    {
        if (keyButtonIndex.Count > 0)
        {
            yield return new WaitForSeconds(waitTime);
            buttons[keyButtonIndex[0]].displayPress(true);

            yield return new WaitForSeconds(displayTime);
            buttons[keyButtonIndex[0]].displayPress(false);

            keyButtonIndex.RemoveAt(0);
            StartCoroutine(showButtons(keyButtonIndex, waitTime, displayTime));
        }
    }

}
