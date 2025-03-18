using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] float startPosX;
	[SerializeField] float endPosX;
	[SerializeField] float spawnStop; // 몬스터 생성 중지 시간
	[SerializeField] GameObject[] monster;
	[SerializeField] GameObject textBossWarning;

	float startTime; // 몬스터 생성 딜레이

	int mosnterIndex = 0;

	int swi = 0;

	void Awake()
	{
		textBossWarning.SetActive( false );
	}

	void Start()
	{
		startTime = Random.Range( 1.5f, 3.5f );

		StartCoroutine( RandomSpawn() );
		if (swi < 3)
		{
			Invoke( "StopSpawn", 0 );
		}
	}

	void Update()
	{

	}

	IEnumerator RandomSpawn() // 몬스터 생성 코루틴
	{
		while (swi < 3)
		{
			yield return new WaitForSeconds( startTime );
			float x = Random.Range( startPosX, endPosX );
			Vector2 y = new Vector2( x, transform.position.y );
			Instantiate( monster[mosnterIndex], y, Quaternion.identity );
			swi++;

			if (swi == 1)
			{
				mosnterIndex++;
			}
			if (swi == 2)
			{
				++mosnterIndex;
				textBossWarning.SetActive( true );
				Invoke( "Hide", 1.5f );
			}
		}
	}

	void StopSpawn()
	{
		StopCoroutine( RandomSpawn() );
	}

	void Hide()
	{
		textBossWarning.SetActive( false );
	}


}
