using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton class used to keep track of persistent game data
/// </summary>
public class GameMaster : MonoBehaviour 
{
	#region Singleton Instances
	private static GameMaster _instance;

	public static GameMaster instance
	{
		get 
		{
			if (_instance == null)
			{
				// Let's find the one and only game master and set 
				// it to the private instance 
				_instance = GameObject.FindObjectOfType<GameMaster>();

				// Tell Unity not to destroy this when loading
				DontDestroyOnLoad(_instance.gameObject);
			}

			// Return the one and only game master
			return _instance;
		}
	}
	#endregion

	#region Player Data
	public int PlayerScore;
	#endregion

	/// <summary>
	/// Awake will happen regardless of whether the script is enabled in the 
	/// inspector or not.  We'll put our initialization code here.
	/// </summary>
	void Awake() 
	{
		// If the provate instance is null then we set it to this object
		// and if it exists but isn't equal to this object we destroy it
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(this.gameObject);
		}
		else if (_instance != this)
		{
			Destroy(this.gameObject);
		}
	}
	
	/// <summary>
	/// Update this instance once per frame
	/// </summary>
	void Update() 
	{
	}
}
