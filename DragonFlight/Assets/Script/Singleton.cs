using UnityEngine;

public class Singleton : MonoBehaviour
{
	public static Singleton Instance { get; private set; }

	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			DontDestroyOnLoad( gameObject );
		}
		else
		{
			Destroy( gameObject );
		}
	}
	void Start()
	{

	}

	void Update()
	{

	}
}
