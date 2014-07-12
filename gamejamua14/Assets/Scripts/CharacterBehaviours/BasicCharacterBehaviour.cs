using UnityEngine;
using System.Collections;

public class BasicCharacterBehaviour : MonoBehaviour
{
		public float MovementSpeed;
		public float CameraSpeed;
		public float JumpAmount;

		[SerializeField]
		protected CharacterController
				myCharacterController;
		[SerializeField]
		protected Camera
				myCamera;

		public Transform ReferenceTransform;

		protected float verticalSpeed;

		// Use this for initialization
		protected virtual void Start ()
		{
		
		}

		void FixedUpdate ()
		{
				ProcessInput ();
		}
	
		// Update is called once per frame
		void Update ()
		{
				ProcessVerticalMovement ();
				ProcessMouseClicks ();
		}

		protected void ProcessInput ()
		{
				Vector3 t_movement = new Vector3 ();

				t_movement += Input.GetAxis ("Vertical") * MovementSpeed * transform.forward;
				t_movement += Input.GetAxis ("Horizontal") * MovementSpeed * transform.right;
				t_movement.y = myCharacterController.velocity.y + Physics.gravity.y * Time.deltaTime * 3.5f + verticalSpeed;

				

				myCharacterController.Move (t_movement * Time.deltaTime);
						
				//Rotation around x
				myCamera.transform.RotateAround (ReferenceTransform.position, ReferenceTransform.right, -Input.GetAxis ("Mouse Y") * Time.deltaTime * CameraSpeed);
				//Rotation around y
				transform.parent.RotateAround (ReferenceTransform.position, ReferenceTransform.up, Input.GetAxis ("Mouse X") * Time.deltaTime * CameraSpeed);
		}

		protected virtual void ProcessVerticalMovement ()
		{
				if (Input.GetKeyDown ("space") && myCharacterController.isGrounded) {
						verticalSpeed = JumpAmount;
						return;
				}

				if (verticalSpeed > 0) {
						verticalSpeed -= 20f * Time.deltaTime;
				}

				if (verticalSpeed < 0) {
						verticalSpeed = 0;
				}
		}

		protected virtual void ProcessMouseClicks ()
		{

		}


}
