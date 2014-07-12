using UnityEngine;
using System.Collections;

public class BossSpiderBehaviour : EnemyBasicBehaviour
{
		public static GameObject Real_NPC;
		public Animator SpiderAnimator;
	
		void Awake ()
		{
				Real_NPC = GameObject.Find ("SpiderRealNPC");
		}

		protected override void Start ()
		{
				base.Start ();		
		}

		void FixedUpdate ()
		{
				if (health > 0) {
						SpiderAnimator.SetFloat (HashIDs.Speed, 1f);
			
						if (!IsInvoking ("attack")) {
								SpiderAnimator.SetTrigger (HashIDs.Attack);
								Invoke ("attack", 0.8f);
								Invoke ("endAttack", 1f);
						}
		
				} else {
						resetScenario ();
				}
		}

		void resetScenario ()
		{
				this.gameObject.SetActive (false);
		}

		protected void attack ()
		{
				//AttackCollider.SetActive (true);
		}
	
		protected void endAttack ()
		{
				//AttackCollider.SetActive (false);
		}
}
