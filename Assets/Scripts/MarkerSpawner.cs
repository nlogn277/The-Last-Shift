using UnityEngine;
using UnityEngine.InputSystem; 
public class MarkerSpawner : MonoBehaviour // This is a public class by the way. So it cn be seena dn interacted with other scripts in this project. Which we want. MakerSpawner is the name of the class 
{
    [SerializeField] private GameObject markerPrefab;
    [SerializeField] private int maxMarkers = 5;
    [SerializeField] private LayerMask groundLayer;

    private int markerCount = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

   
    // Update is called once per frame
    void Update()
    {
        //Making sure a mouse is available
        if (Mouse.current == null)
                {
                    return;
                }
        //if a right mouse button was pressed we're going to ... delete a marker
        if (Mouse.current.rightButton.wasPressedThisFrame)
        {   // Get the mouse position for the right click
            Vector2 rightMousePosition = Mouse.current.position.ReadValue();
            Ray rightRay = Camera.main.ScreenPointToRay(rightMousePosition);
            //Check to see what the mouse is pointing at
            if (Physics.Raycast(rightRay, out RaycastHit rightHit, 100f))
            {
                //You're doing to delete only if the mouse points at object tagged marker
                if (rightHit.collider.CompareTag("Marker"))
                {
                    Destroy(rightHit.collider.transform.parent.gameObject);
                    markerCount--;
                }
            }
            //stop here so the richt click doesn't continue into the left click code
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

        Vector2 mousePosition = Mouse.current.position.ReadValue(); //Vector 2 holds x,y values so petty much its tracking mouse position.

        Ray ray = Camera.main.ScreenPointToRay(mousePosition); //It helps translate the mouse from a 2d screen to the 3d space.

        if (Physics.Raycast(ray, out RaycastHit hit, 100f, groundLayer)) //basically says if you shoot the ray 100units into the scene. Does it hit a collider belonging to the selected ground layer.
        {
            Instantiate(markerPrefab, hit.point, Quaternion.identity); //this spawns the markerprefab where the ray hits the ground layer at
            markerCount++; //marekrcount increases by one
        }

    }
}
