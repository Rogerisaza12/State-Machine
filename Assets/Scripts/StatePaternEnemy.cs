using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatePaternEnemy : MonoBehaviour {


	[SerializeField]
	private GameObject bulletPref;

	[SerializeField]
	private float bulletSpeed;


	public Transform eyes;
	public float radiusSphere;
	public float maxMagnitud;
	public float fireRate;



	[HideInInspector] public IEnemyState currentState;
	[HideInInspector] public PatrolState patrolState;
	[HideInInspector] public KillState killState;
	[HideInInspector] public Transform target;


	public float elapsedTime;
	public float elapsedTime2;
	public int actualPoint;

	public float timePath;

	public Vector3[] path = new Vector3[2];

	void Awake ()
	{

		patrolState = new PatrolState (this);
		killState = new KillState (this);

	}

	// Use this for initialization
	void Start () {
		currentState = patrolState;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime2 += Time.deltaTime;
		currentState.UpdateState ();
	}

	public void Shoot()
	{
		GameObject tempBullet = Instantiate (bulletPref, eyes.position, eyes.rotation);
		tempBullet.GetComponent<Rigidbody> ().AddRelativeForce (Vector3.forward*bulletSpeed, ForceMode.Impulse);
	}

	public void TimePath ()
	{
		elapsedTime += Time.deltaTime;
	}

	private void OnDrawGizmos()
	{
		Vector3 startPosition = eyes.transform.position;

		Vector3 endPosition = startPosition + (transform.forward * maxMagnitud);
		Debug.DrawLine (startPosition, endPosition);
		Gizmos.DrawWireSphere (endPosition, radiusSphere);
	}
}
