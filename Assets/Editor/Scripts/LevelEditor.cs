using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class LevelEditor : EditorWindow
{
	private Transform _parent;
	private EditorData _data;
	private int _index;

	[MenuItem("Window/Level Editor")]
	public static void Init()
	{
		LevelEditor levelEditor = GetWindow<LevelEditor>("Level Editor");
		levelEditor.Show();
	}

	private void OnGUI()
	{
		EditorGUILayout.Space(10);
		_parent = (Transform)EditorGUILayout.ObjectField(_parent, typeof(Transform), true);
		EditorGUILayout.Space(30);

		if (_data == null)
		{
			if (GUILayout.Button("Load data"))
			{
				_data = (EditorData)AssetDatabase.LoadAssetAtPath("Assets/Editor/Data/EditorData.asset", typeof(EditorData));
			}
		}
		else
		{
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			GUILayout.Label("Block Prefab", EditorStyles.boldLabel);
			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();

			GUILayout.Space(5);
			GUILayout.BeginHorizontal();
			GUILayout.FlexibleSpace();
			if (GUILayout.Button("<", GUILayout.Width(50), GUILayout.Height(50)))
			{
				_index--;
				if (_index < 0)
				{
					_index = _data.BlocksData.Count - 1;
				}
			}

			if (_data.BlocksData[_index].BlockData is ColoredBlock)
			{
				ColoredBlock coloredBlock = _data.BlocksData[_index].BlockData as ColoredBlock;
				GUI.color = coloredBlock.BaseColor;
			}
			else
			{
				GUI.color = Color.white;
			}

			GUILayout.Label(_data.BlocksData[_index].Texture2D);
			GUI.color = Color.white;

			if (GUILayout.Button(">", GUILayout.Width(50), GUILayout.Height(50)))
			{
				_index++;
				if (_index > _data.BlocksData.Count - 1)
				{
					_index = 0;
				}
			}

			GUILayout.FlexibleSpace();
			GUILayout.EndHorizontal();
		}
	}
}