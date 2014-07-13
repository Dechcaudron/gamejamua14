using UnityEngine;
using System.Collections;

public class SharkCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public float AttackDamage;
		public GameObject Arrow;
		public float CastDistance;
		public float ShotSpeed;

		public float SwimSpeed;
		public float FloatPower;

		protected override void Start ()
		{
				base.Start ();

				StaticRefs.Refs.SharkPlayer = gameObject;
				gameObject.SetActive (false);
		}

		protected override void ProcessMouseClicks ()
		{
				base.ProcessMouseClicks ();

				if (Input.GetMouseButtonDown (0)) {
						shoot ();
				}
		}

		protected void shoot ()
		{
				
				GameObject t_shot = GameObject.Instantiate (Arrow, transform.position + transform.forward * CastDistance, Quaternion.identity) as GameObject;
				//t_shot.rigidbody.isKinematic = false;
				t_shot.rigidbody.velocity = myCamera.transform.forward * ShotSpeed;
				t_shot.transform.rotation = Quaternion.LookRotation (myCamera.transform.forward);
				//t_shot.rigidbody.isKinematic = true;

		}

		protected override void ProcessVerticalMovement ()
		{
				if (Input.GetKey ("space")) {
						verticalSpeed = SwimSpeed;
				}

				if (verticalSpeed > FloatPower) {
						verticalSpeed -= 5f * Time.deltaTime;
				}

				if (verticalSpeed < FloatPower)
						verticalSpeed = FloatPower;
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				
		}

		public void ExtTriggerStay (Collider a_collider)
		{
		
		}

		public void ExtTriggerExit (Collider a_collider)
		{
		
		}
}
