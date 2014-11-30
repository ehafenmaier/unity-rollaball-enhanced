using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{
	#region Public Variables
	public GameObject player;
	#endregion

	#region Private Variables
	private Vector3 offset;
	#endregion

	// Use this for initialization
	void Start() 
	{
		offset = transform.position;
	}
	
	// LateUpdate is called last during the update cycle
	void LateUpdate()
	{
		transform.position = player.transform.position + offset;
	}
}
