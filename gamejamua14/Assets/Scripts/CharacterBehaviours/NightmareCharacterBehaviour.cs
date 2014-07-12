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

		}

		public void _Die ()
		{

		}
		
		protected override void Start ()
		{
				_OwnedBy = gameObject;
				_MaxHealth = maxHealth;
				_Health = maxHealth;
		}
}
