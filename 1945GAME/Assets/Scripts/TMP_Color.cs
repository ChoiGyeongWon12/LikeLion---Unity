using System.Collections;
using TMPro;
using UnityEngine;

public class TMP_Color : MonoBehaviour
{

	[SerializeField] float lerpTime;


	TextMeshProUGUI textBossWarning;

	void Awake()
	{
		textBossWarning = GetComponent<TextMeshProUGUI>();
	}

	void Update()
	{

	}

	void OnEnable()
	{
		StartCoroutine( "ColorLerpLoop" );
	}


	IEnumerator ColorLerpLoop()
	{
		while (true)
		{
			yield return StartCoroutine( ColorLerp( Color.white, Color.red ) );
			yield return StartCoroutine( ColorLerp( Color.red, Color.white ) );
		}
	}
	IEnumerator ColorLerp(Color start, Color end)
	{
		float currentTime = 0.0f;
		float percent = 0.0f;

		while (percent < 1)
		{
			currentTime += Time.deltaTime;
			percent = currentTime / lerpTime;
			textBossWarning.color = Color.Lerp( start, end, percent );
			yield return null;
		}
	}
}
