using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	[Range(100.0f, 800.0f)]
	public float speed;

	void FixedUpdate()
	{
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
		if (other.gameObject.tag == "PickUp")
		{
			other.gameObject.SetActive(false);
		}
	}
	#endregion
}
