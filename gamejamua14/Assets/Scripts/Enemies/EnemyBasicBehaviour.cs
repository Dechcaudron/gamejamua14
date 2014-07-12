using UnityEngine;
using System.Collections;

public class EnemyBasicBehaviour : MonoBehaviour, IKillable, IAttackable
{

		public static GameControl GameCtrl;

		public int MaxHealth;
		protected float	health;
		protected float damage;

		public bool busy;
		//public bool Damage;
		public bool Die;
		public bool chasingPlayer;

		public float speed;

		public int _MaxHealth {
				get {
						return MaxHealth;
				}
				set {
						MaxHealth = value;
				}
		}
	
		public float _Health {
				get {
						return health;
				}
		
				set {
						health = value;
				}
		}
	
		public GameObject _OwnedBy {
				get;
				set;
		}

		public void _TakeDamage (float a_damage)
		{
				//print ("ouch");
				//Damage = true;
				health -= a_damage;
				if (health <= 0)
						_Die ();
		}
	
		public void _Die ()
		{
				health = 0;
				Die = true;
				Invoke ("fade", 3f);
		}

		public float _Damage {
				get {
						return damage;
				}

				set {
						damage = value;
				}
		}

		public void _Attack (float a_damage)
		{

		}

		private void fade ()
		{
				GameObject.Instantiate (StaticRefs.Refs.Smoke, transform.position, Quaternion.identity);
				Destroy (gameObject);
		}

		protected virtual void Start ()
		{
				//TODO: fill this
				GameCtrl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
				health = MaxHealth;
				//print (0);
		}

		void FixedUpdate ()
		{
				//TODO: fill this
		}

	
		public bool checkLocalPlayer (GameObject LocalPlayer)
		{
				if (LocalPlayer.gameObject.activeInHierarchy) {
						return true;
				} else {
						return false;
				}
		}

		public void chaseObjective (GameObject a_Objective)
		{
				transform.LookAt (a_Objective.transform.position, Vector3.up);
						
				Quaternion rotation = transform.rotation;
				rotation.x = 0;
				rotation.z = 0;
				transform.rotation = rotation;

				transform.Translate (transform.forward * speed * Time.deltaTime, Space.World);
		}
}
