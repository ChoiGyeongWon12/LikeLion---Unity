using UnityEngine;

public class Monster : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float delay;
	[SerializeField] Transform ms1;
	[SerializeField] Transform ms2;
	[SerializeField] GameObject bullet;
	[SerializeField] GameObject item;


	public int HP = 100;


	void Start()
	{
		Invoke( "CreateBullet", delay );
	}

	void Update()
	{
		MoveBullet();
	}

	void MoveBullet()
	{
		transform.Translate( Vector2.down * speed * Time.deltaTime );
	}

	void OnBecameInvisible()
	{
		Destroy( gameObject );
	}

	void CreateBullet() // 몬스터 미사일 재귀호출
	{
		Instantiate( bullet, ms1.position, Quaternion.identity );
		Instantiate( bullet, ms2.position, Quaternion.identity );
		Invoke( "CreateBullet", delay );
	}

	public void ItemDrop()
	{
		Instantiate( item, transform.position, Quaternion.identity );
	}

	public void Damage(int attack)
	{
		HP -= attack;
		if (HP <= 0)
		{
			ItemDrop();
			Destroy( gameObject );
		}

	}
}
