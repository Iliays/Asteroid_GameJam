using System.Collections.Generic;
using UnityEngine;

public class BlocksGenerator : MonoBehaviour
{
    [SerializeField] private List<ColoredBlock> _blocks = new ();

	private void Start()
	{
		for (int i = 0; i < _blocks.Count; i++)
		{
			GameObject gameObject = Instantiate(_blocks[i].Prefab, new Vector3(-3 + i, 0, 0), Quaternion.identity);
			if (gameObject.TryGetComponent(out Block block))
			{
				block.SetData(_blocks[i]);
			}
		}
		for (int i = 0; i < _blocks.Count; i++)
		{
			GameObject gameObject = Instantiate(_blocks[i].Prefab, new Vector3(3 + i, 1, 0), Quaternion.identity);
			if (gameObject.TryGetComponent(out Block block))
			{
				block.SetData(_blocks[i]);
			}
		}
	}
}