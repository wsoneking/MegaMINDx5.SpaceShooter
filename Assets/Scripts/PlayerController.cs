using UnityEngine;
using System.Collections;


[System.Serializable]
public class Boundary
{
	public float Xmin, Xmax, Zmin, Zmax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public float tilt;
	public Boundary boundary;

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;

	void Update()
	{
		if ((Input.GetKey ("space")||Input.GetButton ("Fire1")) && Time.time > nextFire) {
			nextFire = Time.time + fireRate ;
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audio.Play ();
		}
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		rigidbody.velocity = movement * speed; 

		rigidbody.position = new Vector3 (
			Mathf.Clamp (rigidbody.position.x, boundary.Xmin, boundary.Xmax),
			0.0f,
			Mathf.Clamp (rigidbody.position.z, boundary.Zmin, boundary.Zmax)
		   );
		rigidbody.rotation = Quaternion.Euler (0.0f, 0.0f, rigidbody.velocity.x * -tilt);
	 }
}
