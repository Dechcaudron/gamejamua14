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

	
		public bool checkLocalPlayer (GameObject LocalPlayer)
		{
			if(LocalPlayer.gameObject.activeInHierarchy){
				return true;
			}else
			{
				return false;
			}
		}

		public void chasePlayer (GameObject a_LocalPlayer, CharacterController a_controller)

		{
			transform.LookAt (a_LocalPlayer.transform.position);
		
			Quaternion rotation = transform.rotation;
			rotation.x = 0;
			rotation.z = 0;
			transform.rotation = rotation;
			a_controller.SimpleMove(transform.forward * speed * Time.deltaTime);
		}

		public void chaseNPC (GameObject npc, CharacterController a_controller)
		{
			transform.LookAt (npc.transform.position);
			Quaternion rotation = transform.rotation;
			rotation.x = 0;
			rotation.z = 0;
			transform.rotation = rotation;
			a_controller.SimpleMove(transform.forward * speed * Time.deltaTime);
		}
}
