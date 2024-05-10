using UnityEngine;
using System.Collections;

public class FollowEnemy : MonoBehaviour
{
	public Vector3 offset;			// The offset at which the Health Bar follows the player.
	
	public  Transform Enemy;		// Reference to the player.


	void Awake ()
	{
		// Setting up the reference.
		//player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update ()
	{
		// Set the position to the player's position with the offset.
		transform.position = Enemy.position + offset;
	}
}
