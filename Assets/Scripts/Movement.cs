using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private Transform cameraTransform;

    public void SetCamera(Transform camera)
    {
        cameraTransform = camera;
    }

    private void Start()
    {
        Debug.Log("Game has started. Waiting for " + gameObject.name + " to move.");
    }

    private void Update()
    {
        //if Nothing is pressed or moved nothing happens.
        if (Keyboard.current == null || cameraTransform == null)
        {
            return;
        }

        //Camera Movements: Horizantal controls left - right and Vertical controls up and down. 
        //0f - the player isn't moving yet.
        float horizantal = 0f;
        float vertical = 0f;

        //if right arrow key or d is pressed move right.
        if (Keyboard.current.rightArrowKey.isPressed || Keyboard.current.dKey.isPressed)
        {
            horizantal = 1f;
        }
        
        //If left arrow key or a is pressed move left. 
        if (Keyboard.current.leftArrowKey.isPressed || Keyboard.current.aKey.isPressed)
        {
            horizantal = -1f;
        }

        //If up down key or s is pressed move backward.
        if (Keyboard.current.downArrowKey.isPressed || Keyboard.current.sKey.isPressed)
        {
            vertical = -1f;
        }
        
        //If up arrow key or w is pressed move foward.
        if (Keyboard.current.upArrowKey.isPressed || Keyboard.current.wKey.isPressed)
        {
            vertical = 1f;
        }
        
        //Moves player forward and backward (they are negative because it was inverted when the game is played).
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        
        //Ensures that the player does not go through the ground and keeps them level with the terrain. 
        //Disables vertical camera movements.
        forward.y = 0f;
        right.y = 0f;
        
        //Makes the movements have a conistent length.
        forward.Normalize();
        right.Normalize();

        //Combines all inputs to movement directions. Then simplifes them with normalize.
        Vector3 movement = (forward * vertical + right * horizantal).normalized;

        transform.position += movement * speed * Time.deltaTime;

    }

}