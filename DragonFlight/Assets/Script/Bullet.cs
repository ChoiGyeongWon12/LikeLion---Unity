using UnityEngine;

public class Bullet : MonoBehaviour
{

	[SerializeField] float moveSpeed;
	[SerializeField] GameObject explosion;

	void Start()
	{

	}

	void Update()
	{
		transform.Translate( 0, moveSpeed * Time.deltaTime, 0 );
	}



	void OnBecameInvisible()
	{
		Destroy( gameObject );
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag( "Enemy" ))
		{
			Instantiate( explosion, transform.position, Quaternion.identity );
			SoundManager.instance.SoundDie();
			GameManager.instance.AddScore( 1 );
			Destroy( gameObject );
		}
	}
}
