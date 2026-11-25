using UnityEngine;

public class ClueItem : MonoBehaviour
{
    [TextArea(5, 10)]
    [SerializeField] private string clueDetails = "Hello";
    [SerializeField] private bool isFlashlightClue = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (ClueDisplayManager.Instance != null)
            {
                // 1. Show clue UI and update CaseManager
                ClueDisplayManager.Instance.ShowClue(clueDetails);
                CaseManager.Instance.ClueFound();

                // 2. Check if the Player has a FlashlightController and unlock it
                // (Using GetComponentInParent in case the Player's collider is on a child object)
                FlashlightController flashlight = other.GetComponentInParent<FlashlightController>();
                if (isFlashlightClue && flashlight != null)
                {
                    flashlight.PickUpFlashlight();
                }

                // 3. Remove the floor flashlight
                Destroy(gameObject);
            }
            else
            {
                Debug.LogError("ClueDisplayManager Instance is Missing! Make sure it's attached to Canvas.");
            }
        }
    }
}