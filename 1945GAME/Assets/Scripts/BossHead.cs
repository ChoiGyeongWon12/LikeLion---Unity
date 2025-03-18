using UnityEngine;

public class BossHead : MonoBehaviour
{

	[SerializeField] GameObject bossBullet;



	public void RightDownGun()
	{
		GameObject go = Instantiate( bossBullet, transform.position, Quaternion.identity );
		go.GetComponent<Boss_Bullet>().SetDirection( new Vector2( 0.3f, -1f ) );

	}
	public void LeftDownGun()
	{
		GameObject go = Instantiate( bossBullet, transform.position, Quaternion.identity );
		go.GetComponent<Boss_Bullet>().SetDirection( new Vector2( -0.3f, -1f ) );

	}

	public void DownGun()
	{
		GameObject go = Instantiate( bossBullet, transform.position, Quaternion.identity );
		go.GetComponent<Boss_Bullet>().SetDirection( new Vector2( 0, -1 ) );

	}
}
