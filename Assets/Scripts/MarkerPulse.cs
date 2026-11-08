using UnityEngine;

public class MarkerPulse : MonoBehaviour
{
    //Controls the speed f the markers pulse
    [SerializeField] private float pulseSpeed = 3f;
    //Contorls how muhch bigger or smaller the marker becomes
    [SerializeField] private float pulseAmount = 0.2f;
    //Here we decalre soemthign to remeber the markers original scale
    private Vector3 startingScale; //This is important becaseu we want the marker to remeber its original size and not lose track of it when it pulses
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { //Saves the marekrs orginal value
       startingScale = transform.localScale; 
    }

    // Update is called once per frame
    void Update()
    {
        // Here it repeatedly scale the marker above and below its original size
        transform.localScale = startingScale *
            (1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount); //trigonometric fucttion of unity helps keep the movement form original to 0.2 scale + and - 1. Sin reuslts get mulitpeld by the scale 0.2 o irs -0.2 nd 0.2
    }
}
