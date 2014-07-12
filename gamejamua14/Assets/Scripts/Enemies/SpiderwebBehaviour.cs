using UnityEngine;
using System.Collections;
using System.Timers;

public class SpiderwebBehaviour : EnemyBasicBehaviour
{
		public GameObject Spider;
		public float SpawnTime;

		public Transform[] Spawns;

		private int counter;

		protected override void Start ()
		{
				counter = 0;
		}

		void FixedUpdate ()
		{
				counter++;
				if (counter / (1 / Time.fixedDeltaTime) >= SpawnTime) {
						spawn ();
				}
		}

		private void spawn ()
		{
				if (SpiderRoomBehaviour.Mobs.Count < NightmareRoomBehaviour.MAX_LIGHTMOBS_PER_SCENE) {
						print ("Webs: " + SpiderRoomBehaviour.Mobs.Count);
						Transform t_spawnPoint = Spawns.GetRandomTransform ();
						GameObject newSpider = GameObject.Instantiate (Spider, t_spawnPoint.position, Quaternion.identity) as GameObject;
						SpiderRoomBehaviour.Mobs.Add(newSpider);
						newSpider.GetComponent<SpiderBehaviour> ().SetSpawn (t_spawnPoint);
				}
		}
}
