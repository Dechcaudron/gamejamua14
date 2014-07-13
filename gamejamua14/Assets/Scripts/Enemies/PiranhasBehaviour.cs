using UnityEngine;
using System.Collections;

public class PiranhasBehaviour : EnemyBasicBehaviour, IReceivesExternalTrigger
{

		public bool isLocalPlayer;
		public static GameObject PiranhasPlayer;
		public static GameObject NPC;

		public GameObject AttackCollider;

		public Animator MyAnimator;

		// Use this for initialization
		void Awake ()
		{
				PiranhasPlayer = StaticRefs.Refs.SharkPlayer;
				NPC = GameObject.Find ("PiranhasNPC");
		}

		// Use this for initialization
		protected override void Start ()
		{
				base.Start ();
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		public override void _Die ()
		{
				base._Die ();
				MyAnimator.SetTrigger (HashIDs.Die);
		}

		protected void FixedUpdate ()
		{
				if (health > 0) {
						checkPlayer ();
						if (isLocalPlayer) {
								chaseObjective3D (PiranhasPlayer);
								if (Vector3.Distance (PiranhasPlayer.transform.position, transform.position) < StopDistance) {
										if (!IsInvoking ("attack")) {
												//Attack
												Invoke ("attack", 0.8f);
												Invoke ("endAttack", 1f);
												MyAnimator.SetTrigger (HashIDs.Attack);
										}
								} else {
										MyAnimator.SetTrigger (HashIDs.GoIdle);
										CancelInvoke ("attack");
										CancelInvoke ("endAttack");
								}

						} else {
								MyAnimator.SetTrigger (HashIDs.GoIdle);
								CancelInvoke ("attack");
								CancelInvoke ("endAttack");
								chaseObjective3D (NPC);
						}
				}
		}

		private void checkPlayer ()
		{
				if (checkLocalPlayer (PiranhasPlayer)) {
						isLocalPlayer = true;
				} else {
						isLocalPlayer = false;
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
						PiranhasPlayer.GetComponent<SharkCharacterBehaviour> ()._TakeDamage (damage);
				}
				endAttack ();
		}
	
		public void ExtTriggerStay (Collider a_collider)
		{
		
		}
	
		public void ExtTriggerExit (Collider a_collider)
		{
		
		}
}
