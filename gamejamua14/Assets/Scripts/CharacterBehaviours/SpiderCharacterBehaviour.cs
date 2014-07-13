using UnityEngine;
using System.Collections;
using System;

public class SpiderCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger
{
		public Animator SwordAnimator;
		public float AttackDamage;
		public AudioClip[] DieSounds;
		public AudioClip[] AttackSounds;
		public AudioClip[] DamageSounds;
		public AudioSource AudioSource;
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

				if (Input.GetMouseButtonDown (0) && !IsInvoking ("finishAttack")) {
						isAttacking = true;
						SwordAnimator.SetTrigger (HashIDs.Attack);
						Invoke ("startAttackSound", 0.1f);
						Invoke ("finishAttack", 0.65f);
				}
		}

		protected void startAttackSound ()
		{
				AudioSource.clip = AttackSounds [UnityEngine.Random.Range (0, DieSounds.Length)];
				AudioSource.Play ();
		}

		protected void finishAttack ()
		{
				isAttacking = false;
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				if (isAttacking && a_collider.tag == "Enemy") {
						isAttacking = false;

						try {
								a_collider.GetComponent<EnemyBasicBehaviour> ()._TakeDamage (AttackDamage);
						} catch (NullReferenceException e) {
								print (0);
								a_collider.GetComponent<BasicBossBehaviour> ()._TakeDamage (AttackDamage);
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
