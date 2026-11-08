using UnityEngine;
using UnityEngine.InputSystem;
public class MarkerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject markerPrefab;
    [SerializeField] private int maxMarkers = 5;
    [SerializeField] private LayerMask groundLayer;

    private int markerCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    // Update is called once per frame
    void Update()
    {
        //Making sure a moouse is available
        if (Mouse.current == null)
                {
                    return;
                }
        //Only continue when theleft button is clicked again at this frame
        if (!Mouse.current.leftButton.wasPressedThisFrame)
        {
            return; //no click? I have nothing to do, goodbye
        }
        if (markerCount >= maxMarkers)
        {
            Debug.Log("Marker limit reached"); //Pretty much if you clicked the marker moe than or 5 times, then you've reached the limit.
            return;
        }

        Vector2 mousePosition = Mouse.current.position.ReadValue(); //Vector 2 holds x,y values so petty muh its tracking mouse position.

        Ray ray = Camera.main.ScreenPointToRay(mousePosition); //It helps translate the mouse from a 2d screen to the 3d space.

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer)) //basically says if you shoot the ray 100units into the scene. Does it hit a collider belonging to the selected ground layer.
        {
            Instantiate(markerPrefab, hit.point, Quaternion.identity); //this spawns the markerprefab where the ray hits the ground layer at
            markerCount++; //marekrcount increases by one
        }

    }
}
