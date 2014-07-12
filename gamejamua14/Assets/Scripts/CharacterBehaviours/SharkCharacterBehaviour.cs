using UnityEngine;
using System.Collections;

public class SharkCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public Animator SwordAnimator;
		public float AttackDamage;
		public float SwimSpeed;
		public float FloatPower;

		private bool isAttacking;

		protected override void Start ()
		{
				base.Start ();

				StaticRefs.Refs.SharkPlayer = gameObject;
				gameObject.SetActive (false);
		}

		protected override void ProcessMouseClicks ()
		{
				base.ProcessMouseClicks ();

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
