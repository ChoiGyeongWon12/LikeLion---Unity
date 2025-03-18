using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	public delegate void ScoreAchieve();

	public event ScoreAchieve scoreAchieve;

	public static GameManager instance;
	[SerializeField] GameObject spawnManager;
	[SerializeField] Text scoreText;
	[SerializeField] Text startText;

	public int score = 0;


	void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy( gameObject );
		}
	}
	void Start()
	{
		StartCoroutine( StartGame() );
	}

	void Update()
	{

	}

	public void AddScore(int num)
	{
		score += num;
		scoreText.text = "Score : " + score;
		if (score == 7)
		{
			scoreAchieve?.Invoke();
		}
		else if (score == 15)
		{
			scoreAchieve?.Invoke();
		}
		else if (score == 25)
		{
			scoreAchieve?.Invoke();
		}
	}
	IEnumerator StartGame()
	{
		int i = 3;
		while (i > 0)
		{
			startText.text = i.ToString();

			yield return new WaitForSeconds( 1 );

			i--;

			if (i == 0)
			{
				startText.gameObject.SetActive( false );  //UI°¨Ãß±â
			}
		}
	}

}

