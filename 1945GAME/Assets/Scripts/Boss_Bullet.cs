using UnityEngine;

public class Boss_Bullet : MonoBehaviour
{

	[SerializeField] float speed;
	Vector2 vec2 = Vector2.down;


	void Start()
	{

	}

	void Update()
	{
		transform.Translate( vec2 * speed * Time.deltaTime );
	}

	public void SetDirection(Vector2 direction)
	{
		vec2 = direction;
	}

	void OnBecameInvisible()
	{
		Destroy( gameObject );
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag( "Player" ))
		{
			Destroy( gameObject );
		}
	}
}
