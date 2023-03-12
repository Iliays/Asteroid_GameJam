using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BallMove : MonoBehaviour
{
	private Rigidbody2D _rigidbody2D;
	private bool _isActiv;
	private readonly float _force = 700f;
	private float _lastPositionX;

	private void Start()
	{
		_rigidbody2D = GetComponent<Rigidbody2D>();
		_rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
	}

	private void Update()
	{
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.Mouse0) && !_isActiv)
		{
			BallActivate();
		}
#endif
#if UNITY_ANDROID
        if (Input.touchCount > 0 && !_isActiv)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.tapCount > 1)
			{
				BallActivate();
			}
		}
#endif
	}

	private void BallActivate()
	{
		_lastPositionX = transform.position.x;
		_isActiv = true;
		transform.SetParent(null);
		_rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
		_rigidbody2D.AddForce(Vector2.up * _force);
	}

	public void MoveCollision(Collision2D collision)
	{
		float ballPositionX = transform.position.x;

		if (collision.gameObject.TryGetComponent(out PlayerMove playerMove))
		{
			if (ballPositionX < _lastPositionX + 0.1 && ballPositionX > _lastPositionX - 0.1) // движение почти вертикальное
			{
				float collisionPointX = collision.contacts[0].point.x; // точка касания
				_rigidbody2D.velocity = Vector2.zero;
				float playerCenterPosition = playerMove.gameObject.transform.position.x;
				float difference = playerCenterPosition - collisionPointX; // разница между центром ваганетки и местом касания
				float direction = collisionPointX < playerCenterPosition ? -1 : 1; // расчет направления 
				_rigidbody2D.AddForce(new Vector2(direction * Mathf.Abs(difference * (_force / 2)), _force));
			}
		}

		_lastPositionX = ballPositionX;
	}
}