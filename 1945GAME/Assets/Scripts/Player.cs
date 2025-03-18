using UnityEngine;

public class Player : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float paddingLeft;
	[SerializeField] float paddingRight;
	[SerializeField] float paddingTop;
	[SerializeField] float paddingBottom;


	public Transform gun;


	[SerializeField] GameObject[] bulletLook;
	[SerializeField] GameObject powerUp;
	[SerializeField] GameObject lazer;
	GameObject la;

	public int playerIndex = 0;
	public float gValue = 0f;
	bool isFiring = false;



	private Vector2 minBounds;
	private Vector2 maxBounds;
	Animator animator;

	void Start()
	{
		animator = GetComponent<Animator>();

		SetCameraBounds(); // 카메라 경계 설정



	}

	void Update()
	{
		PlayerMove(); // 설정된 경계 안에서 플레이어 이동
		Fire(); //총알 발사
	}

	void SetCameraBounds()
	{
		// 화면의 경계를 설정
		Camera cam = Camera.main;
		Vector3 bottomLeft = cam.ViewportToWorldPoint( new Vector3( 0, 0, 0 ) );
		Vector3 topRight = cam.ViewportToWorldPoint( new Vector3( 1, 1, 0 ) );

		minBounds = new Vector2( bottomLeft.x, bottomLeft.y );
		maxBounds = new Vector2( topRight.x, topRight.y );
	}


	void PlayerMove()
	{
		// 플레이어 이동
		float moveX = Input.GetAxisRaw( "Horizontal" ) * speed * Time.deltaTime;
		float moveY = Input.GetAxisRaw( "Vertical" ) * speed * Time.deltaTime;

		Vector3 newPosition = transform.position + new Vector3( moveX, moveY, 0 );

		// 경계를 벗어나지 않도록 위치 제한
		newPosition.x = Mathf.Clamp( newPosition.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight );
		newPosition.y = Mathf.Clamp( newPosition.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop );

		//위치 제한 내에서 플레이어 이동
		transform.position = newPosition;

		if (Input.GetAxisRaw( "Horizontal" ) <= -0.5f)
		{
			animator.SetBool( "left", true );
		}
		else
		{
			animator.SetBool( "left", false );
		}

		if (Input.GetAxisRaw( "Horizontal" ) >= 0.5f)
		{
			animator.SetBool( "right", true );
		}
		else
		{
			animator.SetBool( "right", false );
		}
		if (Input.GetAxisRaw( "Vertical" ) >= 0.5f)
		{
			animator.SetBool( "up", true );
		}
		else
		{
			animator.SetBool( "up", false );
		}
	}

	void Fire()
	{
		if (Input.GetKeyDown( KeyCode.Space ))
		{
			Instantiate( bulletLook[playerIndex], gun.transform.position, Quaternion.identity );
		}
		else if (Input.GetKey( KeyCode.V ) && !isFiring)  // 발사 중이지 않을 때만 발사
		{
			gValue += Time.deltaTime;
			if (gValue >= 1)  // 게이지가 가득 찼을 때
			{
				GameObject go = Instantiate( lazer, gun.transform.position, Quaternion.identity );
				Destroy( go, 1f );

				gValue = 0;  // 게이지 초기화
				isFiring = true;  // 발사 중 상태로 설정
			}
		}
		else if (Input.GetKeyUp( KeyCode.V ))  // V키를 뗐을 때
		{
			gValue = 0;  // 게이지 초기화
			isFiring = false;  // 발사 중 상태 해제
		}
		else
		{
			gValue -= Time.deltaTime;
			if (gValue <= 0)
				gValue = 0;
		}




	}



	void OnTriggerEnter2D(Collider2D collision) // 아이템 획득 시 업글
	{
		if (collision.CompareTag( "Item" ))
		{
			playerIndex++;
			if (playerIndex >= 3)
				playerIndex = 3;
			else
			{
				GameObject po = Instantiate( powerUp, transform.position, Quaternion.identity );
				Destroy( po, 1f );
			}

			Destroy( collision.gameObject );
		}
	}


}
