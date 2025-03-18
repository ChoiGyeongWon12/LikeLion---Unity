using UnityEngine;

public class MBullet : MonoBehaviour
{

	float speed;



	void Start()
	{
		speed = Random.Range( 1.5f, 3f );
		Destroy( gameObject, 5f );
	}

	void Update()
	{
		MoveMBullet();
	}

	void MoveMBullet()
	{
		transform.Translate( Vector2.down * speed * Time.deltaTime );
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag( "Player" ))
		{
			Destroy( gameObject );
			//Destroy( collision.gameObject );
		}
	}
}
