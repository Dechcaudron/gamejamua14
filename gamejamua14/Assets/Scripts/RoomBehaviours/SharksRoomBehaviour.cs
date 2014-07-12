using UnityEngine;
using System.Collections;

public class SharksRoomBehaviour : NightmareRoomBehaviour
{

		public float EnemyDensity;
		public GameObject Piranha;
		public GameObject PiranhaSpot;
		public Transform[] PiranhaSpawns;
		public Transform[] WebSpawns;
		public float SecondsBetweenWaves;

		// Use this for initialization
		protected override void Start ()
		{
				base.Start ();
	
				InvokeRepeating ("SpawnWave", SecondsBetweenWaves, SecondsBetweenWaves);
		}
	
		protected override void FixedUpdate ()
		{
				base.FixedUpdate ();
		}

		void SpawnWave ()
		{
				int t_toSpawn = Mathf.RoundToInt (EnemyDensity * MadnessPercentage);
				int t_leftToSpawn = t_toSpawn;
		
				if (MadnessPercentage < 0.33) {
						//Spawn little shit
						while (t_leftToSpawn-- >0) {
								spawnPiranha (PiranhaSpawns.GetRandomTransform ());
						}
			
				} else if (MadnessPercentage < 0.66) {
						//Spawn piranhaspots and little shit
						while (t_leftToSpawn-->t_toSpawn*0.2) {
								//Little shit
								spawnPiranha (PiranhaSpawns.GetRandomTransform ());
						}
						while (t_leftToSpawn-->0) {					
								//piranhaspots
								GameObject t_newSpot = GameObject.Instantiate (PiranhaSpot) as GameObject;
				
								t_newSpot.transform.position = PiranhaSpawns.GetRandomTransform ().position;
						}
				} else {
						//Spawn the shitload
						while (t_leftToSpawn-->t_toSpawn*0.5) {
								//Little shit
								spawnPiranha (PiranhaSpawns.GetRandomTransform ());
						}
						while (t_leftToSpawn-->0) {					
								//Spiderwebs
								GameObject t_newSpot = GameObject.Instantiate (PiranhaSpot) as GameObject;
				
								t_newSpot.transform.position = PiranhaSpawns.GetRandomTransform ().position;
						}
				}
		
		}
	
		void spawnPiranha (Transform a_spawn)
		{
				if (LightMobs.Count < NightmareRoomBehaviour.MAX_LIGHTMOBS_PER_SCENE) {
						GameObject t_newPiranha = GameObject.Instantiate (Piranha, a_spawn.position, Quaternion.identity) as GameObject;
						LightMobs.Add (t_newPiranha);
						t_newPiranha.GetComponent<SpiderBehaviour> ().SetSpawn (a_spawn);
				}
		}
}
