using UnityEngine;
using System.Collections;

public abstract class NightmareCharacterBehaviour : BasicCharacterBehaviour, IDamageable, IKillable
{
		[SerializeField]
		private int
				maxHealth;

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
				_Health -= a_damage;
				print ("Players health:" + _Health);
		}

		public void _Die ()
		{
				_Health = 0;
		}
		
		protected override void Start ()
		{
				_OwnedBy = gameObject;
				_MaxHealth = maxHealth;
				_Health = maxHealth;
		}
}
