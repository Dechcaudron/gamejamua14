using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpiderRoomBehaviour : NightmareRoomBehaviour
{
		public float EnemyDensity;
		public GameObject Spiderweb;
		public GameObject Spider;
		public Transform[] SpiderSpawns;
		public Transform[] WebSpawns;
		public float SecondsBetweenWaves;
		public static List<GameObject> Mobs;

		public Material webMaterial;
	
		protected override void Start ()
		{
				base.Start ();
				CurrentBossTheme = BOSS_MUSIC_SPIDER;
				SpiderBehaviour.myRoomBehaviour = this;
				SpiderwebBehaviour.myRoomBehaviour = this;

				Mobs = LightMobs;

				InvokeRepeating ("SpawnWave", SecondsBetweenWaves, SecondsBetweenWaves);
		}

		protected override void FixedUpdate ()
		{
				//print (MadnessPercentage);
				base.FixedUpdate ();

				webMaterial.SetFloat ("_Cutoff", -MadnessPercentage + 1f);
		}

		void SpawnWave ()
		{
				int t_toSpawn = Mathf.RoundToInt (EnemyDensity * MadnessPercentage);
				int t_leftToSpawn = t_toSpawn;

				if (MadnessPercentage < 0.33) {
						//Spawn little shit
						while (t_leftToSpawn-- >0) {
								spawnSpider (SpiderSpawns.GetRandomTransform ());
						}

				} else if (MadnessPercentage < 0.66) {
						//Spawn spiderwebs and little shit
						while (t_leftToSpawn-->t_toSpawn*0.2) {
								//Little shit
								spawnSpider (SpiderSpawns.GetRandomTransform ());
						}
						while (t_leftToSpawn-->0) {					
								//Spiderwebs
								GameObject t_newWeb = GameObject.Instantiate (Spiderweb) as GameObject;

								t_newWeb.transform.position = WebSpawns.GetRandomTransform ().position;
						}
				} else {
						//Spawn the shitload
						while (t_leftToSpawn-->t_toSpawn*0.5) {
								//Little shit
								spawnSpider (SpiderSpawns.GetRandomTransform ());
						}
						while (t_leftToSpawn-->0) {					
								//Spiderwebs
								GameObject t_newWeb = GameObject.Instantiate (Spiderweb) as GameObject;
					
								t_newWeb.transform.position = WebSpawns.GetRandomTransform ().position;
						}
				}
			
		}

		void spawnSpider (Transform a_spawn)
		{
				if (BossSpiderBehaviour.IsAwake)
						return;

				if (LightMobs.Count < NightmareRoomBehaviour.MAX_LIGHTMOBS_PER_SCENE) {
						GameObject t_newSpider = GameObject.Instantiate (Spider, a_spawn.position, Quaternion.identity) as GameObject;
						LightMobs.Add (t_newSpider);
						t_newSpider.GetComponent<SpiderBehaviour> ().SetSpawn (a_spawn);
				}
		}
}
