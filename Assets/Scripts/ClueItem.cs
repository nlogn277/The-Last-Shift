using System;
using Unity.VisualScripting;
using UnityEngine;

public class ClueItem : MonoBehaviour
{
    [TextArea(3, 5)] //Makes a wide text box in the Inspector.
    [SerializeField] private string clueDetails = "Hello";

    private void OnTriggerEnter(Collider other)
    {
        //Check if the object colliding with the Clue is Player.
        if (other.CompareTag("Player"))
        {
            //Send the text to UI Manager Popup.
            if(ClueDisplayManager.Instance != null)
            {
                //show the clue ot the player
                ClueDisplayManager.Instance.ShowClue(clueDetails);
                //Report the collected c;ue ot the casemanager
                CaseManager.Instance.ClueFound();
                //Remove collected clue
                Destroy(gameObject);
            }

            else
            {
                Debug.LogError("ClueDisplayManager Instance is Missing! Make sure it's attached to Canvas.");
            }
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
