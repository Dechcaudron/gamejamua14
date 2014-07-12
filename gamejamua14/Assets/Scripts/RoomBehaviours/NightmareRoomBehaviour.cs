using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class NightmareRoomBehaviour : RoomBehaviour
{

		public const float MadnessToBoss = 50f;
		public const float LIGHT_INTENSITY_MULTIPLIER = 80f;
		public GameObject Boss;
		public List<GameObject> LightMobs;
		public static int MAX_LIGHTMOBS_PER_SCENE = 20;

		public Light MyLight;

		void Start (){
			LightMobs = new List<GameObject> ();
		}

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

				if (MadnessPercentage >= 1)
						ChangeToBoss ();
		} 

		public void ChangeToBoss(){
			for(int i = 0; i<LightMobs.Count; i++){
				Destroy(LightMobs[i]);
				LightMobs.Remove(LightMobs[i]);
			}
			if(Boss != null)
		   	{
				Boss.SetActive(true);
			}
		}
}