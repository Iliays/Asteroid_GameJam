using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EditorData", menuName = "EditorData/Create/Data")]
public class EditorData : ScriptableObject
{
	public List<EditorBlockData> BlocksData = new();
}

[System.Serializable]
public class EditorBlockData
{
	public Texture2D Texture2D;
	public BlockData BlockData;
}