using UnityEngine;

public class Bullet : MonoBehaviour
{
	[SerializeField] float BulletVelocity;
	[SerializeField] GameObject effect;

	public int attack = 15;

	void Start()
	{
		Destroy( gameObject, 1.7f );
	}

	void Update()
	{
		transform.Translate( Vector2.up * BulletVelocity * Time.deltaTime );
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag( "Monster" ))
		{
			GameObject ef = Instantiate( effect, transform.position, Quaternion.identity );
			Destroy( ef, 1f );

			collision.gameObject.GetComponent<Monster>().Damage( attack );

			Destroy( gameObject );
		}

		if (collision.gameObject.CompareTag( "Boss" ))
		{
			GameObject ef = Instantiate( effect, transform.position, Quaternion.identity );
			Destroy( ef, 1f );


			Destroy( gameObject );
		}
	}
}
