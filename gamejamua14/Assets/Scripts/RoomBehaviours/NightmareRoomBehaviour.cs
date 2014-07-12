﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class NightmareRoomBehaviour : RoomBehaviour
{
		public const float MadnessToBoss = 50f;
		public const float LIGHT_INTENSITY_MULTIPLIER = 40f;
		public GameObject Boss;
		public List<GameObject> LightMobs;
		public static int MAX_LIGHTMOBS_PER_SCENE = 20;
		public GameObject Walls;
		public float WallSpeed;
		public Transform OpenPosition;
		public Transform ClosedPosition;
		public bool isBossAwake = false;
		public Light MyLight;
		private bool isOpen;

		protected virtual void Start ()
		{
				LightMobs = new List<GameObject> ();
				Open ();
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

		public void Open ()
		{
				isOpen = true;
		}

		public void Close ()
		{
				isOpen = false;
		}

		public void LowerMadness (float a_amount)
		{
				Madness -= a_amount;
				if (Madness < 0)
						Madness = 0;
		}

		protected virtual void FixedUpdate ()
		{
				MyLight.intensity = MadnessPercentage * LIGHT_INTENSITY_MULTIPLIER;

				if (isOpen) {
						Walls.transform.position = Vector3.Lerp (Walls.transform.position, OpenPosition.position, WallSpeed);
				} else {
						Walls.transform.position = Vector3.Lerp (Walls.transform.position, ClosedPosition.position, WallSpeed);
				}

				if (Madness < MadnessToBoss)
						Madness += gameControl.MadnessIncreaseSpeed;

				if (Madness > MadnessToBoss)
						Madness = MadnessToBoss;

				if (MadnessPercentage >= 1)
						ChangeToBoss ();
		}

		public void ChangeToBoss ()
		{

				for (int i = 0; i<LightMobs.Count; i++) {
						Destroy (LightMobs [i]);
						LightMobs.Remove (LightMobs [i]);
				}
				if (Boss != null) {
						Boss.SetActive (true);
				}
		}

		public void ResetSector ()
		{	
				Boss.SetActive (false);
				Madness = 0;
		}
}