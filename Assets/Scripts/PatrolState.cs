using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : IEnemyState {

	private readonly StatePaternEnemy enemy;

	public PatrolState(StatePaternEnemy statePaternEnemy)
	{
		enemy = statePaternEnemy;
	}

	public void UpdateState (){
		RotateTurret ();
		CheckTime ();
		Look ();
		enemy.TimePath ();
	}

	public void ToKillState (){
		enemy.currentState = enemy.killState;
	}

	public void ToPatrolState (){
		Debug.Log ("Are you fucking kidding");
	}

	void Look()
	{
		RaycastHit hit;
	
		if (Physics.SphereCast(enemy.eyes.position,enemy.radiusSphere,enemy.eyes.forward,out hit,enemy.maxMagnitud))
		{
			if (hit.collider.gameObject.tag == "player") {
				enemy.target = hit.transform;
				ToKillState ();
			}
				
		}

	}

	void RotateTurret()
	{
		Vector3 rotationNow = Vector3.Lerp (enemy.path [enemy.actualPoint], enemy.path [(enemy.actualPoint+1)%enemy.path.Length], enemy.elapsedTime / enemy.timePath);

		enemy.transform.eulerAngles = rotationNow;

	}

	void CheckTime ()
	{

		if (enemy.elapsedTime >= enemy.timePath) 
		{

			enemy.actualPoint ++;
			enemy.actualPoint = enemy.actualPoint % enemy.path.Length;
			enemy.elapsedTime = 0;

		}

	}
}
