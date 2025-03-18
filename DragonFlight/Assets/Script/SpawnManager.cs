using UnityEngine;

public class SpawnManager : MonoBehaviour
{
	[SerializeField] GameObject[] enemy;
	int currentIndex = 0;

	void Start()
	{
		InvokeRepeating( "SpawnEnemy", 3.1f, 1.2f );
		GameManager.instance.scoreAchieve += InCreaseIndex;
	}

	void Update()
	{
		if (GameManager.instance.score >= 26)
		{
			CancelInvoke( "SpawnEnemy" );
		}
	}

	void SpawnEnemy()
	{
		GameObject currentEnemy = enemy[currentIndex];
		float randX = Random.Range( -2f, 2f );
		Instantiate( currentEnemy, new Vector3( randX, transform.position.y, 0 ), Quaternion.identity );
	}

	void InCreaseIndex()
	{
		if (currentIndex < enemy.Length - 1)
		{
			currentIndex++;
		}
	}
}
