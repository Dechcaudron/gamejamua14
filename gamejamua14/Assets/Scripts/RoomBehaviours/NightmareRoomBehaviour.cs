using UnityEngine;
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
		public float OpenHeight;
		public float ClosedHeight;
		public bool isBossAwake = false;
		public Light MyLight;
		private bool isOpen;
		public const int BOSS_MUSIC_SPIDER = 0;
		public const int BOSS_MUSIC_SHARK = 1;
		public const int BOSS_MUSIC_PANEL = 2;
		public const int BOSS_MUSIC_ROBOT = 3;
		public const int BOSS_MUSIC_NORMAL = 4;
		public int CurrentBossTheme = 0;

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
				if (!isBossAwake) {
						MyLight.intensity = MadnessPercentage * LIGHT_INTENSITY_MULTIPLIER;

						if (isOpen) {
								Walls.transform.position = new Vector3 (Walls.transform.position.x, Mathf.Lerp (Walls.transform.position.y, OpenHeight, WallSpeed), Walls.transform.position.z);
						} else {
								Walls.transform.position = new Vector3 (Walls.transform.position.x, Mathf.Lerp (Walls.transform.position.y, ClosedHeight, WallSpeed), Walls.transform.position.z);
						}

						if (Madness < MadnessToBoss)
								Madness += gameControl.MadnessIncreaseSpeed;

						if (Madness > MadnessToBoss)
								Madness = MadnessToBoss;

						if (MadnessPercentage >= 1)
								ChangeToBoss ();
				}
		}

		public void ChangeToBoss ()
		{

				for (int i = 0; i<LightMobs.Count; i++) {
						Destroy (LightMobs [i]);
				}
				LightMobs = new List<GameObject> ();

				if (Boss != null) {
						isBossAwake = true;
						Boss.SetActive (true);
						changeMusicTheme ();
				}
		}

		public void ChangeToNormal ()
		{
				isBossAwake = false;
				Boss.SetActive (false);
		}

		public void ResetSector ()
		{	
				Boss.SetActive (false);
				Madness = 0;
		}

		private void changeMusicTheme ()
		{
			StaticRefs.Refs.GlobalSound.ChangeToBoss (CurrentBossTheme);
		}
}