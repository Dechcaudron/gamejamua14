using UnityEngine;
using System.Collections;

public class SpiderCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public Animator SwordAnimator;
		public float AttackDamage;

		private bool isAttacking;

		protected override void Start ()
		{
				StaticRefs.Refs.SpiderPlayer = gameObject;
				gameObject.SetActive (false);
		}

		protected override void ProcessMouseClicks ()
		{
				base.ProcessMouseClicks ();

				if (Input.GetMouseButtonDown (0)) {
						SwordAnimator.SetTrigger (HashIDs.Attack);
				}
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				if (isAttacking) {
						if (a_collider.tag == "Enemy") {
								a_collider.GetComponent<EnemyBasicBehaviour> ()._TakeDamage (AttackDamage);
						}
				}
		}

		public void ExtTriggerStay (Collider a_collider)
		{
		
		}

		public void ExtTriggerExit (Collider a_collider)
		{
		
		}
}
