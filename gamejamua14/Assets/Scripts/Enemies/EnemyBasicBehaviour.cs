using UnityEngine;
using System.Collections;

public class EnemyBasicBehaviour : MonoBehaviour, IKillable, IAttackable
{

		public static GameControl GameCtrl;

		public int MaxHealth;
		protected float	health;
		protected float damage;

		public bool busy;
		public bool Damage;
		public bool Die;
		public bool chasingPlayer;

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

		public void _TakeDamage (float a_damage, Vector3 a_hitPoint)
		{
				Damage = true;
				// StartCoroutine (TestCoroutine ()); //TODO: replace
				health -= a_damage;
				if (health <= 0)
						_Die ();
		}
	
		public void _Die ()
		{
				health = 0;
				// GameCtrl.ZombiesOnStage--; //TODO: replace 
				Die = true;
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

		void Start ()
		{
				//TODO: fill this
		}

		void FixedUpdate ()
		{
				//TODO: fill this
		}

		void checkPlayerVisibility ()
		{
				//Already chasing the player?
				if (chasingPlayer)
						return; //Yes, return
		
				//Direct vision with player? Go chase that little bitch
				if (false) { //TODO: fix this
//						StartCoroutine (chasePlayer ());
				}
		}

		/*protected IEnumerator chasePlayer ()
	{

	}*/
}
