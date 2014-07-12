using UnityEngine;
using System.Collections;

public abstract class NightmareRoomBehaviour : RoomBehaviour
{
		public const float MadnessToBoss = 50f;

		public float MadnessPercentage {
				get {
						return Madness / MadnessToBoss;
				}
		}

		protected float Madness;

		protected GameControl gameControl;
		
		void Awake ()
		{
				gameControl = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameControl> ();
		}

		protected virtual void FixedUpdate ()
		{
				if (Madness < MadnessToBoss)
						Madness += gameControl.MadnessIncreaseSpeed;

				if (Madness > MadnessToBoss)
						Madness = MadnessToBoss;
		} 
}