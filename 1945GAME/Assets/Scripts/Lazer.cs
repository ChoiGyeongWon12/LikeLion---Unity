using UnityEngine;

public class Lazer : MonoBehaviour
{

	[SerializeField] GameObject effect;
	Transform pos;
	int attack = 10;

	void Start()
	{
		pos = GameObject.Find( "Player" ).GetComponent<Player>().gun;
	}

	void Update()
	{
		transform.position = pos.position;
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Monster")
		{
			collision.gameObject.GetComponent<Monster>().Damage( attack++ );
			CreateEffect( collision.transform.position );
		}

		if (collision.gameObject.tag == "Boss")
		{
			CreateEffect( collision.transform.position );
		}
	}

	void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Monster")
		{
			collision.gameObject.GetComponent<Monster>().Damage( attack++ );
			CreateEffect( collision.transform.position );
		}

		if (collision.gameObject.tag == "Boss")
		{
			CreateEffect( collision.transform.position );
		}
	}

	void CreateEffect(Vector2 vector)
	{
		GameObject eff = Instantiate( effect, vector, Quaternion.identity );
		Destroy( eff, 1f );
	}
}
