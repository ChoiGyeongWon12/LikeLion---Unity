using UnityEngine;

public class Enemy : MonoBehaviour
{

	[SerializeField] float moveSpeed;
	[SerializeField] float hp;

	void Start()
	{

	}

	void Update()
	{
		float idstanceY = moveSpeed * Time.deltaTime;
		transform.Translate( 0, -idstanceY, 0 );
	}
	void OnBecameInvisible()
	{
		Destroy( gameObject );
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Bullet")
		{
			hp -= 1;
			if (hp <= 0)
			{
				Destroy( gameObject );
			}
		}
	}
}
