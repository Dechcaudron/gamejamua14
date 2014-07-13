using UnityEngine;
using System.Collections;

public class BossSpiderBehaviour : BasicBossBehaviour
{
		public static bool IsAwake;
		public float StartHeight;
		public float EndHeight;
		public float DropSpeed;
		public AudioSource attackSoundSource;
		public AudioClip attackClip;
		public AudioClip dieClip;

		protected void attack ()
		{
				//AttackCollider.SetActive (true);
		}
	
		protected void endAttack ()
		{
				//AttackCollider.SetActive (false);
		}

		void FixedUpdate ()
		{
				transform.position = new Vector3 (transform.position.x, Mathf.Lerp (transform.position.y, EndHeight, DropSpeed * Time.deltaTime), transform.position.z);
		}

		void OnEnable ()
		{
				IsAwake = true;
				Revive ();
				if (!attackSoundSource.isPlaying) {
						attackSoundSource.clip = attackClip;
						attackSoundSource.loop = true;
						attackSoundSource.Play ();
				}
		}

		void OnDisable ()
		{
				if (attackSoundSource.isPlaying) {
						attackSoundSource.Stop ();
				}
				attackSoundSource.clip = dieClip;
				attackSoundSource.loop = false;
				attackSoundSource.Play ();

				CancelInvoke ("killNPC");
				IsAwake = false;
				Vector3 newPosition = transform.position;
				newPosition.y = StartHeight;
				transform.position = newPosition;
		}
}
