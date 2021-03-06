﻿using UnityEngine;
using System.Collections;

public class ArrowBehaviour : MonoBehaviour
{
		public float TimeToDie;
		public float Damage;
		public AudioSource audioSource;
		public AudioClip launchSound;

		void Start ()
		{
				audioSource.clip = launchSound;
				audioSource.volume = 1;
				audioSource.loop = false;
				audioSource.Play ();
		}

		void OnCollisionEnter (Collision a_collision)
		{
				if (a_collision.collider.gameObject.tag == "Enemy") {
						a_collision.collider.gameObject.GetComponent<EnemyBasicBehaviour> ()._TakeDamage (Damage);
				}

				Invoke ("Fade", TimeToDie);
		}

		void Fade ()
		{
				GameObject.Instantiate (StaticRefs.Refs.Bubbles, transform.position, Quaternion.identity);
				Destroy (gameObject);
		}

		void OnTriggerExit (Collider a_collider)
		{
				if (a_collider.name == "TriggerSharks") {
						Fade ();
				}
		}
}
