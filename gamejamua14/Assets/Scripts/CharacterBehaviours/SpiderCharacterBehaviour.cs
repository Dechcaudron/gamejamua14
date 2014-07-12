using UnityEngine;
using System.Collections;
using System;

public class SpiderCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public Animator SwordAnimator;
		public float AttackDamage;

		private bool isAttacking;

		protected override void Start ()
		{
				base.Start ();

				StaticRefs.Refs.SpiderPlayer = gameObject;
				gameObject.SetActive (false);
		}

		protected override void ProcessMouseClicks ()
		{
				base.ProcessMouseClicks ();

				if (Input.GetMouseButtonDown (0) && !IsInvoking ("cancelAttack")) {
						isAttacking = true;
						SwordAnimator.SetTrigger (HashIDs.Attack);
						Invoke ("cancelAttack", 0.6f);
				}
		}

		void cancelAttack ()
		{
				isAttacking = false;
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				//print ("triggerENter");
				if (a_collider.isTrigger)
						return;

				if (isAttacking) {
						isAttacking = false;
						
						if (a_collider.tag == "Enemy") {
								try {
										a_collider.GetComponent<EnemyBasicBehaviour> ()._TakeDamage (AttackDamage);
								} catch (NullReferenceException e) {
										a_collider.GetComponent<BasicBossBehaviour> ()._TakeDamage (AttackDamage);
										//print (a_collider.GetComponent<BasicBossBehaviour> ()._Health);
								}
						}
				}
		}

		public void ExtTriggerStay (Collider a_collider)
		{
				ExtTriggerEnter (a_collider);
		}

		public void ExtTriggerExit (Collider a_collider)
		{
		
		}
}
