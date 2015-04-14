using UnityEngine;
using System.Collections;

[System.Serializable]

public class Boundary
{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	private bool moving;
	private bool rotated;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, moveVertical , 0.0f);
		GetComponent<Rigidbody2D>().velocity = movement * speed;


		GetComponent<Rigidbody2D>().position = new Vector3
		(
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.x, boundary.xMin, boundary.xMax),
				Mathf.Clamp (GetComponent<Rigidbody2D>().position.y, boundary.yMin, boundary.yMax),
				0.0f
		);

		//rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);

		if (Input.GetKey (KeyCode.A))
			//transform.right = GetComponent<Rigidbody2D>().velocity.x;
			transform.right = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
		else if (Input.GetKey(KeyCode.D))
			transform.right = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, 0);
	
	}	
	
}
