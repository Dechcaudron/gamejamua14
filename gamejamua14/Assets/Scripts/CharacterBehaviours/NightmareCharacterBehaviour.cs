using UnityEngine;
using System.Collections;

public abstract class NightmareCharacterBehaviour : BasicCharacterBehaviour, IDamageable, IKillable
{
		public Transform Respawn;

		[SerializeField]
		private int
				maxHealth;
		[SerializeField]
		private float
				deathTime;

		[SerializeField]
		protected NightmareRoomBehaviour
				myRoomBehaviour;

		protected bool isDead;

		public GameObject _OwnedBy {
				get;
				set;
		}

		public int _MaxHealth {
				get;
				set;
		}

		public float _Health {
				get;
				set;
		}

		public void _TakeDamage (float a_damage)
		{
				MyAnimator.SetTrigger ("Suffer");
				_Health -= a_damage;
				print ("Players health:" + _Health);

				if (_Health <= 0)
						_Die ();
		}

		public void _Die ()
		{
				_Health = 0;
				myRoomBehaviour.Close ();
				Invoke ("revive", deathTime);
				transform.parent.position = Respawn.position;
		}

		private void revive ()
		{
				_Health = _MaxHealth;
				myRoomBehaviour.Open ();
		}
		
		protected override void Start ()
		{
				_OwnedBy = gameObject;
				_MaxHealth = maxHealth;
				_Health = maxHealth;
		}
	
}
