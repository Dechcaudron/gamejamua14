using UnityEngine;
using System.Collections;

public class SpiderBehaviour : EnemyBasicBehaviour
{
	
		public bool isLocalPlayer;
		public static GameObject SpiderPlayer;
		public static GameObject NPC;
		public float BuriedAmount;
		public float RiseSpeed;

		protected Rigidbody rigidbody;
		protected Transform spawn;

		// Use this for initialization
		void Awake ()
		{
				rigidbody = GetComponent<Rigidbody> ();
				SpiderPlayer = StaticRefs.Refs.SpiderPlayer;
				NPC = GameObject.Find ("SpiderNPC");
				
		}

		void Start ()
		{
				print ("started");
				transform.Translate (-Vector3.up * BuriedAmount);
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}

		void FixedUpdate ()
		{
				verticalMovement ();
				checkPlayer ();
				if (isLocalPlayer) {
						chaseObjective (SpiderPlayer);
				} else {
						chaseObjective (NPC);
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

}
