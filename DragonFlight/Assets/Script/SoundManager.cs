using UnityEngine;

public class SoundManager : MonoBehaviour
{
	public static SoundManager instance;

	AudioSource myAudio;

	[SerializeField] AudioClip fireSound;
	[SerializeField] AudioClip dieSound;

	[Range( 0f, 1f )] public float fireVolumef;  // ÃÑ¾Ë ¹ß»ç ¼Ò¸® º¼·ý
	[Range( 0f, 1f )] public float dieVolumef;   // ¸ó½ºÅÍ Á×´Â ¼Ò¸® º¼·ý

	void Awake()
	{
		if (SoundManager.instance == null)
		{
			SoundManager.instance = this;
		}

	}
	void Start()
	{
		myAudio = GetComponent<AudioSource>();
	}

	void Update()
	{

	}

	public void SoundFire()
	{
		myAudio.PlayOneShot( fireSound, fireVolumef );
	}
	public void SoundDie()
	{
		myAudio.PlayOneShot( dieSound, dieVolumef );
	}
}
