using UnityEngine;
// Tracks collected clues and unlocks the storage door
public class CaseManager : MonoBehaviour
{
    //allows other scripts to reach this case manager.
    public static CaseManager Instance;
    [SerializeField] private int cluesNeeded = 3;

    private int cluesFound = 0;

    [SerializeField] private Renderer doorRenderer;

    [SerializeField] private Material unlockedMaterial;

    private void Awake()
    {
       
        if (Instance == null) Instance = this; //stores this case manager as the shared instance
        else Destroy(gameObject);
    }

    public void ClueFound()
    {
        //Add one to the clue count
        cluesFound++;

        //print curetn count for testing
        Debug.Log("Clues Found: "+ cluesFound);
        //TURN THE DOOR GREEN ONCE ENOUGH CLUES ARE FOUND
        if (cluesFound >=cluesNeeded)
        {
            doorRenderer.material = unlockedMaterial;
        }
    }
    //this answers whether the required number of clues have been found.
    public bool IsCaseSolved()
    {
        return cluesFound >= cluesNeeded;
    }
    
}
