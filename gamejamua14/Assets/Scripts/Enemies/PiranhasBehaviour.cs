using UnityEngine;
using System.Collections;

public class PiranhasBehaviour : EnemyBasicBehaviour, IReceivesExternalTrigger {

	public bool isLocalPlayer;
	public static GameObject PiranhasPlayer;
	public static GameObject NPC;

	public GameObject AttackCollider;

	// Use this for initialization
	void Awake ()
	{
		PiranhasPlayer = StaticRefs.Refs.PiranhasPlayer;
		NPC = GameObject.Find ("PiranhasNPC");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate (){
		if (health > 0) {
			checkPlayer ();
			if (isLocalPlayer) {
				chaseObjective (PiranhasPlayer);

				
			} else {
				CancelInvoke ("attack");
				CancelInvoke ("endAttack");
				chaseObjective (NPC);
			}
		}
	}

	private void checkPlayer ()
	{
		if (checkLocalPlayer (PiranhasPlayer)) {
			isLocalPlayer = true;
		} else {
			isLocalPlayer = false;
		}
	}
	
	protected void attack ()
	{
		AttackCollider.SetActive (true);
	}
	
	protected void endAttack ()
	{
		AttackCollider.SetActive (false);
	}

	public void ExtTriggerEnter (Collider a_collider)
	{
		if (a_collider.gameObject.tag == "Player") {
			PiranhasPlayer.GetComponent<SpiderCharacterBehaviour> ()._TakeDamage (damage);
		}
	}
	
	public void ExtTriggerStay (Collider a_collider)
	{
		
	}
	
	public void ExtTriggerExit (Collider a_collider)
	{
		
	}
}
