using UnityEngine;
using System.Collections;

public class TimedDestroyer : MonoBehaviour
{
		public float LifeTime;

		// Use this for initialization
		void Start ()
		{
				Invoke ("Die", LifeTime);
		}

		void Die ()
		{
				Destroy (this);
		}
}
