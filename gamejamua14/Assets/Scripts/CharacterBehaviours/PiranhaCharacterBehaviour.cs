﻿using UnityEngine;
using System.Collections;

public class PiranhaCharacterBehaviour : NightmareCharacterBehaviour, IReceivesExternalTrigger {

	public Animator SwordAnimator;
	public float AttackDamage;
	
	private bool isAttacking;
	
	protected override void Start ()
	{
		StaticRefs.Refs.PiranhasPlayer = gameObject;
		gameObject.SetActive (false);
	}
	
	protected override void ProcessMouseClicks ()
	{
		base.ProcessMouseClicks ();
		
		if (Input.GetMouseButtonDown (0)) {
			isAttacking = true;
			SwordAnimator.SetTrigger (HashIDs.Attack);
		}
	}
	
	public void ExtTriggerEnter (Collider a_collider)
	{
		if (isAttacking) {
			isAttacking = false;
			
			if (a_collider.tag == "Enemy") {
				a_collider.GetComponent<EnemyBasicBehaviour> ()._TakeDamage (AttackDamage);
			}
		}
	}
	
	public void ExtTriggerStay (Collider a_collider)
	{
		
	}
	
	public void ExtTriggerExit (Collider a_collider)
	{
		
	}

	protected override void ProcessVerticalMovement()
	{
		//TODO: Configure vertical movement
	}
}
