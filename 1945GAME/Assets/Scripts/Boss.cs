using System.Collections;
using UnityEngine;

public class Boss : MonoBehaviour
{
	int flag = 1;
	float speed;
	float bulletDelay;

	[SerializeField] float bossY;
	[SerializeField] GameObject mb1;
	[SerializeField] GameObject mb2;
	[SerializeField] Transform ms1;
	[SerializeField] Transform ms2;



	void Start()
	{
		StartCoroutine( BossMissle() );
		StartCoroutine( CircleFire() );

		speed = Random.Range( 0.5f, 3f );
		bulletDelay = 0.7f;
	}

	void Update()
	{
		if (transform.position.x >= 1)
		{
			flag = -1;
		}
		if (transform.position.x <= -1)
		{
			flag = 1;
		}
		transform.Translate( flag * speed * Time.deltaTime, 0, 0 );
	}


	IEnumerator BossMissle()
	{
		while (true)
		{
			Instantiate( mb1, ms1.position, Quaternion.identity );
			Instantiate( mb1, ms2.position, Quaternion.identity );

			yield return new WaitForSeconds( bulletDelay );
		}
	}

	IEnumerator CircleFire()
	{
		//�����ֱ�
		float attackRate = 3;
		//�߻�ü ��������
		int count = 30;
		//�߻�ü ������ ����
		float intervalAngle = 360 / count;
		//���ߵǴ� ����(�׻� ���� ��ġ�� �߻����� �ʵ��� ����
		float weightAngle = 0f;

		//�� ���·� ����ϴ� �߻�ü ����(count ���� ��ŭ)
		while (true)
		{

			for (int i = 0; i < count; i++)
			{
				//�߻�ü ����
				GameObject clone = Instantiate( mb2, transform.position, Quaternion.identity );

				//�߻�ü �̵� ����(����)
				float angle = weightAngle + intervalAngle * i;
				//�߻�ü �̵� ����(����)
				//Cos(����)���� ������ ���� ǥ���� ���� pi/180�� ����
				float x = Mathf.Cos( angle * Mathf.Deg2Rad );
				//sin(����)���� ������ ���� ǥ���� ���� pi/180�� ����
				float y = Mathf.Sin( angle * Mathf.Deg2Rad );

				//�߻�ü �̵� ���� ����
				clone.GetComponent<Boss_Bullet>().SetDirection( new Vector2( x, y ) );
			}
			//�߻�ü�� �����Ǵ� ���� ���� ������ ���Ѻ���
			weightAngle += 1;

			//3�ʸ��� �̻��� �߻�
			yield return new WaitForSeconds( attackRate );

		}




	}

	void MoveBoss()
	{

	}




}
