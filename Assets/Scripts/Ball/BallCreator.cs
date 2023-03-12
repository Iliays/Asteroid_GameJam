using UnityEngine;

public class BallCreator : MonoBehaviour
{
	[SerializeField] private GameObject ballPrefab;
	private readonly float _offsetY = 0.5f;

	private void Start()
	{
		Create();
	}

	public void Create()
	{
		Instantiate(ballPrefab, new Vector3(transform.position.x, transform.position.y + _offsetY), Quaternion.identity, transform);
	}
}