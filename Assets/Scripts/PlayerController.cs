using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	#region Public Variables
	// Using the Range attribute to set the minimum and maximum the 
	// speed variable can be set to. This attribute will create a
	// slider in the inspector.
	[Range(100.0f, 800.0f)]
	public float speed;
	// Reference to the UI Text object that will display the score
	public Text scoreText;
	#endregion

	#region Private Variables
	// Variable to hold the score of the game (the number of PickUp
	// objects collected)
	// private int score;
	#endregion

	void Start()
	{
		// Initialize the score to zero
		GameMaster.instance.PlayerScore = 0;
		UpdateScoreDisplay();
	}

	void FixedUpdate()
	{
		// Grab the values of the keyboard input (arrow keys)
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		// Create movement vector from input
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		// Add force to the player object based on movement vector
		rigidbody.AddForce(movement * speed * Time.deltaTime);
	}

	#region Trigger Collider Methods
	void OnTriggerEnter(Collider other) 
	{
		// Check if the game object that the player object has 
		// collided with is tagged "PickUp". If true, disable
		// the game object and increase the score by one
		if (other.gameObject.tag == "PickUp")
		{	 
			other.gameObject.SetActive(false);

			// score++;
			GameMaster.instance.PlayerScore++;

			UpdateScoreDisplay();
		}
	}
	#endregion
	
	void UpdateScoreDisplay()
	{
		scoreText.text = string.Format("Score: {0}", GameMaster.instance.PlayerScore);
	}
}
