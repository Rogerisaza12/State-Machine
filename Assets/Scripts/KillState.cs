using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillState : IEnemyState {

	private StatePaternEnemy enemy;

	public KillState(StatePaternEnemy statePaternEnemy)
	{

		enemy = statePaternEnemy;

	}

	public void UpdateState ()
	{
		Debug.Log ("KillYourSelf");
		CheckDistance ();
		RotateToTarget ();
		CheckShoot ();
	}

	public void ToKillState ()
	{
		Debug.Log ("Are you fucking kidding");
	}

	public void ToPatrolState ()
	{
		enemy.currentState = enemy.patrolState;
	}

	void CheckDistance ()
	{
		float distance =  (enemy.target.position - enemy.transform.position).magnitude;

		if (distance > (enemy.maxMagnitud+1.5f))
			ToPatrolState ();

	}

	void CheckShoot(){

		if (enemy.elapsedTime2 > enemy.fireRate) {
		
			enemy.elapsedTime2 = 0;
			enemy.Shoot ();
		
		}

	}

	void RotateToTarget ()
	{
		enemy.transform.rotation = Quaternion.LookRotation (enemy.target.position-enemy.transform.position);
			
	}

}
