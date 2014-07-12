using UnityEngine;
using System.Collections;

public class BasicBossBehaviour : MonoBehaviour, IKillable, IDamageable
{
		public NightmareRoomBehaviour MyRoomBehaviour;

		public float SecondsToKill;

		[SerializeField]
		protected int
				maxHealth;

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

				if (_Health <= 0)
						_Die ();
		}

		public void _Die ()
		{
				_Health = 0;
				CancelInvoke ("killNPC");
				MyRoomBehaviour.ChangeToNormal ();
		}

		public void Revive ()
		{
				_Health = _MaxHealth;
				Invoke ("killNPC", SecondsToKill);
		}

		void Start ()
		{
				_Health = maxHealth;
				_MaxHealth = maxHealth;
				gameObject.SetActive (false);
		}

		void killNPC ()
		{
				GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ().EndGame ();
		}
}
