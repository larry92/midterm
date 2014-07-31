using UnityEngine;
using System.Collections;

public class TransformController : MonoBehaviour {

	public float speed = 10;
	public float rotateSpeed = 10;
	public float gravity = 50;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		//shortcut for controller compontent
		CharacterController controller = GetComponent<CharacterController>();
		
		//Rotate Player Capsule Horizontally
		float rotateHorizontal = Input.GetAxis ("Mouse X") * rotateSpeed * Time.deltaTime;
		transform.Rotate (0, rotateHorizontal, 0);
		
		//establish movement axis and normalize vectors
		Vector3 strafeMove = transform.right * (Input.GetAxis ("Horizontal"));
		Vector3 forwardMove = transform.forward * (Input.GetAxis ("Vertical"));
		Vector3 moveDirection = strafeMove + forwardMove;
		
		//Player Movement
		controller.SimpleMove (moveDirection * speed * Time.deltaTime);
		
		//Add Gravity
		moveDirection.y -= gravity;
	}
}
