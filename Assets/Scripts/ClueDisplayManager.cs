using UnityEngine;
using TMPro;
using System;
using UnityEngine.InputSystem;

public class ClueDisplayManager : MonoBehaviour
{
    public static ClueDisplayManager Instance; //Allows clues to talk to UI easier.

    [SerializeField] private GameObject cluePanel;
    [SerializeField] private TextMeshProUGUI clueText;

    private void Awake()
    {
        //Conditional Statement.
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowClue(string clueDescription)
    {
        //Displays the clue's text and sets the clue to true so it activates.
        clueText.text = clueDescription;
        cluePanel.SetActive(true);

        //Pauses the game/locks players movement while Clue is open.
        Time.timeScale = 0f;
    }

    public void CloseClue()
    {
        //Hides the panel and restores game to default value.
        cluePanel.SetActive(false);
        Time.timeScale = 1f;
    }



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        //Press Space or click to close the clue popup
        if (cluePanel.activeSelf && Keyboard.current.spaceKey.isPressed)
        {
            CloseClue();
        }
    }
}
