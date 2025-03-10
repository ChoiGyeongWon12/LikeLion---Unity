using UnityEngine;

public class BackGroundRepeat : MonoBehaviour
{
	[SerializeField] float scrollSpeed;
	Material material;

	void Start()
	{
		material = GetComponent<Renderer>().material;
	}

	void Update()
	{
		Vector2 newOffset = material.mainTextureOffset;
		newOffset.Set( 0, newOffset.y + ( scrollSpeed * Time.deltaTime ) );
		material.mainTextureOffset = newOffset;
	}
}
