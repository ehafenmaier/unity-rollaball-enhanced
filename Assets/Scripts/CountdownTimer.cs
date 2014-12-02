using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour 
{
	#region Public Variables
	// Start time with range that shows a slider in the inspector
	[Range(0, 60)]
	public int startTime = 15;
	// Time to add when PickUp object is collected
	[Range(0, 15)]
	public int timeToAdd = 0;
	// Reference to UI Text object that will display the timer
	public Text timerText;
	#endregion

	#region Private Variables
	private float countdown;
	#endregion

	void Start()
	{
		// Let's initialize the countdown with the start time
		countdown = (float)startTime;
	}
	
	void Update() 	
	{
		// Deduct the delta time if the countdown is greater than zero
		// and if it's less than zero set it to zero
		if (countdown < 0.0f)
		{
			countdown = 0.0f;
			UpdateTimerDisplay();
		}
		else if (countdown > 0.0f)
		{
			countdown -= Time.deltaTime;
			UpdateTimerDisplay();
		}	
	}

	#region Trigger Collider Methods
	void OnTriggerEnter(Collider other) 
	{
		// Check if the game object that the player object has 
		// collided with is tagged "PickUp". If true, add time
		// to the countdown
		if (other.gameObject.tag == "PickUp")
		{	 
			countdown += (float)timeToAdd;
		}
	}
	#endregion

	void UpdateTimerDisplay()
	{
		timerText.text = string.Format("Time: {0:00.00}", countdown);	
	}
}
