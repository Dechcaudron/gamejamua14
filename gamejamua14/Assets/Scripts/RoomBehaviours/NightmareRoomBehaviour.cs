using UnityEngine;
using System.Collections;

public abstract class NightmareRoomBehaviour : RoomBehaviour
{

		public const float MadnessToBoss = 50f;
		public const float LIGHT_INTENSITY_MULTIPLIER = 80f;

		public Light MyLight;


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
				MyLight.intensity = MadnessPercentage * LIGHT_INTENSITY_MULTIPLIER;

				if (Madness < MadnessToBoss)
						Madness += gameControl.MadnessIncreaseSpeed;

				if (Madness > MadnessToBoss)
						Madness = MadnessToBoss;
		} 
}