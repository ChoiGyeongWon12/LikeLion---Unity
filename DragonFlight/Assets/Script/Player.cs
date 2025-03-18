using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{

	[SerializeField] float moveSpeed;
	[SerializeField] GameObject enemy;
	bool canMove = false;



	void Start()
	{
		StartCoroutine( StartPlayerMove() );
	}

	void Update()
	{

	}

	void FixedUpdate()
	{
		if (canMove)
		{
			PlayerMove();
		}
	}

	void PlayerMove()
	{
		float distanceX = Input.GetAxisRaw( "Horizontal" ) * moveSpeed * Time.deltaTime;
		transform.Translate( distanceX, 0, 0 );
	}

	IEnumerator StartPlayerMove()
	{
		yield return new WaitForSeconds( 3.1f );
		canMove = true;
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy( gameObject );
		}
	}

}
