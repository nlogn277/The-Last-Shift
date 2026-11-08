using UnityEngine;
//Show the appropriate door message whne the player enters the trigger 
public class StorageDoor : MonoBehaviour
{

    //message shows after all clues have been collected
    [TextArea(3,5)]
    [SerializeField] private string endingText = "Case solved! The storage door shut behind Eli and his card snapped. He's safe, and very Hungry";

    //Message shows if the clues are still missing
    [TextArea(3,5)]
    [SerializeField] private string lockedText = "The door is locked. Find all 3 clues first.";

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Only respond whne the player enters trigger
            if (other.CompareTag("Player"))
            {
                //Sho the ending if the case is solved
                if (CaseManager.Instance.IsCaseSolved())
                {
                    ClueDisplayManager.Instance.ShowClue(endingText);
                }
                else
                {
                    //Otherwise explain that the door is still loed
                    ClueDisplayManager.Instance.ShowClue(lockedText);
                }
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
