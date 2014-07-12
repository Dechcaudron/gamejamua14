using UnityEngine;
using System.Collections;

public class SharkCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public Animator SwordAnimator;
		public float AttackDamage;

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
