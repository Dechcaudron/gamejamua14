using UnityEngine;
using System.Collections;

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

				if (Input.GetMouseButtonDown (0)) {
						isAttacking = true;
						SwordAnimator.SetTrigger (HashIDs.Attack);
						AudioSource.clip = AttackSounds [Random.Range (0, DieSounds.Length)];
						AudioSource.Play ();

				}
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				if (isAttacking) {
						isAttacking = false;

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
