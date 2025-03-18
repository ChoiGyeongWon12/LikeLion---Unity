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
		target = GameObject.FindGameObjectWithTag( "Player" ); // �÷��̾ �±׷� ã��
		dir = target.transform.position - transform.position; // �÷��̾ �ٶ󺸴� ���� ���ϱ�
		dirNo = dir.normalized; // ���� ����ȭ
		Destroy( gameObject, 5f );
	}

	void Update()
	{
		transform.Translate( dirNo * speed * Time.deltaTime ); // �÷��̾ ���� �̵�
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player") // �÷��̾�� �ε�����
		{
			Destroy( gameObject ); // �̻��� ����

		}
	}
}
