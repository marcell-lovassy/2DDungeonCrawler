using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

public static class GeneralMenuItems
{
	public readonly static string StartScene = "Menu";

	[MenuItem("Tools/Start game")]
	public static void StartGame()
	{
		EditorSceneManager.OpenScene($"Assets/Scenes/{StartScene}.unity");
		EditorApplication.isPlaying = true;
	}
}
