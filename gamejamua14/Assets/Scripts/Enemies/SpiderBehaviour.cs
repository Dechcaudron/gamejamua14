﻿using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour, IReceivesExternalTrigger
{
	
		public bool isLocalPlayer;
		public static GameObject SpiderPlayer;
		public static GameObject NPC;
		public float BuriedAmount;
		public float RiseSpeed;
		public GameObject AttackCollider;

		public Animator SpiderAnimator;
	
		protected Transform spawn;

		// Use this for initialization
		void Awake ()
		{
				SpiderPlayer = StaticRefs.Refs.SpiderPlayer;
				NPC = GameObject.Find ("SpiderNPC");
		}

		protected override void Start ()
		{
				base.Start ();

				transform.Translate (-Vector3.up * BuriedAmount);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				if (health > 0) {
						verticalMovement ();
						checkPlayer ();
						if (isLocalPlayer) {
								chaseObjective (SpiderPlayer);

								SpiderAnimator.SetFloat (HashIDs.Speed, 1f);

								if (Vector3.Distance (SpiderPlayer.transform.position, transform.position) < StopDistance) {
										
										if (!IsInvoking ("attack")) {
												SpiderAnimator.SetTrigger (HashIDs.Attack);
												Invoke ("attack", 0.8f);
												Invoke ("endAttack", 1f);
										}

								} else {
										CancelInvoke ("attack");
										CancelInvoke ("endAttack");
								}

						} else {
								CancelInvoke ("attack");
								CancelInvoke ("endAttack");
								if (Vector3.Distance (NPC.transform.position, transform.position) > StopDistance + 1) {
										chaseObjective (NPC);
								} else {
										SpiderAnimator.SetTrigger (HashIDs.GoIdle);
								}
						}
				} else {
						SpiderAnimator.SetTrigger (HashIDs.Die);
				}
		}

		public void SetSpawn (Transform a_spawn)
		{
				spawn = a_spawn;
		}

		public override void _Die ()
		{
				base._Die ();
				myRoomBehaviour.LightMobs.Remove (gameObject);
		}

		private void checkPlayer ()
		{
				if (checkLocalPlayer (SpiderPlayer)) {
						isLocalPlayer = true;
				} else {
						isLocalPlayer = false;
				}
		}

		private void verticalMovement ()
		{
				if (transform.position.y < spawn.position.y) {
						transform.Translate (Vector3.up * Time.deltaTime * RiseSpeed, Space.World);
				} else {
						rigidbody.isKinematic = false;
				}
		}

		protected void attack ()
		{
				AttackCollider.SetActive (true);
		}

		protected void endAttack ()
		{
				AttackCollider.SetActive (false);
		}

		public void ExtTriggerEnter (Collider a_collider)
		{
				//print (a_collider);
				if (a_collider.gameObject.tag == "Player") {
					
						SpiderPlayer.GetComponent<SpiderCharacterBehaviour> ()._TakeDamage (damage);
						endAttack ();
				}
		}

		public void ExtTriggerStay (Collider a_collider)
		{
			
		}

		public void ExtTriggerExit (Collider a_collider)
		{
		
		}

		void OnTriggerExit (Collider a_collider)
		{
				if (a_collider.gameObject.name == "TriggerSpiders") {
						_Die ();
				}
		}
}
