using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
	Rigidbody rb;
	[SerializeField] float jumpPower = 5f;
	[SerializeField] float speed = 5f;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update()
	{
		float x = Input.GetAxis( "Horizontal" );
		float z = Input.GetAxis( "Vertical" );

		transform.Translate( x * speed * Time.deltaTime, 0, 0 );
		transform.Translate( 0, 0, z * speed * Time.deltaTime );
		if (Input.GetKeyDown( KeyCode.Space ))
		{
			rb.AddForce( Vector3.up * jumpPower, ForceMode.Impulse );
		}
	}
}
