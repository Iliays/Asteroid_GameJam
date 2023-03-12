using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollisions : MonoBehaviour
{
    [SerializeField] private BallMove _ballMove;

	private void OnCollisionEnter2D(Collision2D collision)
	{
		_ballMove.MoveCollision(collision);

		if (collision.gameObject.TryGetComponent(out Block block))
		{
			block.ApplyDamage();
		}
	}
}