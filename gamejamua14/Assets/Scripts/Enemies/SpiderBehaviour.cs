using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour, IReceivesExternalTrigger
{
	
		public bool isLocalPlayer;
		public static GameObject SpiderPlayer;
		public static GameObject NPC;
		public float BuriedAmount;
		public float RiseSpeed;
		public GameObject AttackCollider;

		protected Rigidbody rigidbody;
		protected Transform spawn;

		// Use this for initialization
		void Awake ()
		{
				rigidbody = GetComponent<Rigidbody> ();
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

								if (Vector3.Distance (SpiderPlayer.transform.position, transform.position) < 0.8f) {
										InvokeRepeating ("attack", 1f, 2f);
										InvokeRepeating ("endAttack", 1.2f, 2f);
								} else {
										CancelInvoke ("attack");
										CancelInvoke ("endAttack");
								}

						} else {
								CancelInvoke ("attack");
								CancelInvoke ("endAttack");
								chaseObjective (NPC);
						}
				}
		}

		public void SetSpawn (Transform a_spawn)
		{
				spawn = a_spawn;
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
				if (a_collider.gameObject.tag == "Player") {
						SpiderPlayer.GetComponent<SpiderCharacterBehaviour> ()._TakeDamage (damage);
				}

		}

		public void ExtTriggerStay (Collider a_collider)
		{
		
		}

		public void ExtTriggerExit (Collider a_collider)
		{
		
		}
}
