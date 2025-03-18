using UnityEngine;

public class MBullet_2 : MonoBehaviour
{

	[SerializeField] GameObject target;
	float speed;

	Vector2 dir;
	Vector2 dirNo;
	void Start()
	{
		speed = Random.Range( 1f, 2.5f );
		target = GameObject.FindGameObjectWithTag( "Player" ); // 플레이어를 태그로 찾기
		dir = target.transform.position - transform.position; // 플레이어를 바라보는 벡터 구하기
		dirNo = dir.normalized; // 벡터 정규화
		Destroy( gameObject, 5f );
	}

	void Update()
	{
		transform.Translate( dirNo * speed * Time.deltaTime ); // 플레이어를 향해 이동
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") // 플레이어와 부딪히면
		{
			Destroy( gameObject ); // 미사일 삭제

		}
	}
}
