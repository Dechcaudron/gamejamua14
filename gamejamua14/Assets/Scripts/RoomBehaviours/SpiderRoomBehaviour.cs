﻿using UnityEngine;
using System.Collections;

public class SpiderRoomBehaviour : NightmareRoomBehaviour
{
		public float EnemyDensity;

		public GameObject Spiderweb;
		public GameObject Spider;

		public Transform[] SpiderSpawns;
		public Transform[] WebSpawns;

		public float SecondsBetweenWaves;

		private int currentCount;

		void Start ()
		{
			
		}

		protected override void FixedUpdate ()
		{
				base.FixedUpdate ();
				
				currentCount++;

				if (currentCount / (1 / Time.fixedDeltaTime) > SecondsBetweenWaves) {
						SpawnWave ();
						currentCount = 0;
				} else {
					
				}
		}

		void SpawnWave ()
		{
				int t_toSpawn = Mathf.RoundToInt (EnemyDensity * MadnessPercentage);
				int t_leftToSpawn = t_toSpawn;

			if(LightMobs.Count < NightmareRoomBehaviour.MAX_LIGHTMOBS_PER_SCENE){

					if (MadnessPercentage < 0.33) {
							//Spawn little shit
							while (t_leftToSpawn-- >0) {
									GameObject t_newSpider = GameObject.Instantiate (Spider) as GameObject;
									LightMobs.Add(t_newSpider);
									t_newSpider.transform.position = SpiderSpawns.GetRandomTransform ().position;
							}

					} else if (MadnessPercentage < 0.66) {
							//Spawn spiderwebs and little shit
							while (t_leftToSpawn-->t_toSpawn*0.2) {
									//Little shit
									GameObject t_newSpider = GameObject.Instantiate (Spider) as GameObject;
									LightMobs.Add(t_newSpider);
									t_newSpider.transform.position = SpiderSpawns.GetRandomTransform ().position;
							}
							while (t_leftToSpawn-->0) {					
									//Spiderwebs
									GameObject t_newWeb = GameObject.Instantiate (Spiderweb) as GameObject;
									
									t_newWeb.transform.position = SpiderSpawns.GetRandomTransform ().position;
							}
					} else {
							//Spawn the shitload
							while (t_leftToSpawn-->t_toSpawn*0.5) {
									//Little shit
									GameObject t_newSpider = GameObject.Instantiate (Spider) as GameObject;
									LightMobs.Add(t_newSpider);
									t_newSpider.transform.position = SpiderSpawns.GetRandomTransform ().position;
							}
							while (t_leftToSpawn-->0) {					
									//Spiderwebs
									GameObject t_newWeb = GameObject.Instantiate (Spiderweb) as GameObject;
					
									t_newWeb.transform.position = SpiderSpawns.GetRandomTransform ().position;
							}
					}
			}
		}
}