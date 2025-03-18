using UnityEngine;

public class Gun : MonoBehaviour
{
	[SerializeField] GameObject bulletPrefab;
	void Start()
	{
		InvokeRepeating( "Fire", 3.1f, 0.5f );
	}

	void Update()
	{

	}

	void Fire()
	{
		Instantiate( bulletPrefab, transform.position, Quaternion.identity );
		SoundManager.instance.SoundFire();
	}
}
