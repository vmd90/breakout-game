using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager {

	private static PlayerInfo playerInfo;
	private static OptionsInfo options;
	private static string nextScene;
	private static int mapNum = 1;

	public static void Initialize()
	{
		Debug.Log(Player);
		Debug.Log(Options);
	}

	public static void NextMap()
	{
		mapNum++;
	}
	/// <summary>
	/// Instantiates new game object.
	/// </summary>
	/// <returns>The game object.</returns>
	/// <param name="name">Name.</param>
	/// <param name="pos">Position.</param>
	/// <param name="parent">Parent.</param>
	public static GameObject CreateObject(string name, Vector3 pos, GameObject parent)
	{
		GameObject gobj = new GameObject(name);
		gobj.transform.position = pos;
		gobj.transform.SetParent(parent.transform);
		return gobj;
	}

	public static GameObject CreateSprite(string name, string path, Vector3 pos, GameObject parent)
	{
		GameObject gobj = CreateObject(name, pos, parent);
		SpriteRenderer sr = gobj.AddComponent<SpriteRenderer>();
		sr.sprite = Resources.Load<Sprite>(path);
		return gobj;
	}

	public static int MapNum
	{
		get {
			return mapNum;
		}
		set {
			mapNum = value;
		}
	}
	/// <summary>
	/// Gets the player.
	/// </summary>
	/// <value>The player.</value>
	public static PlayerInfo Player
	{
		get {
			if (playerInfo == null) {
				playerInfo = new PlayerInfo();
			}
			return playerInfo;
		}
	}
	/// <summary>
	/// Gets the options info.
	/// </summary>
	/// <value>The options.</value>
	public static OptionsInfo Options
	{
		get {
			if (options == null) {
				options = new OptionsInfo();
			}
			return options;
		}
	}

	public static string NextScene
	{
		get {
			return nextScene;
		}
		set {
			nextScene = value;
		}
	}
	/// <summary>
	/// Loads the 'Loading' scene and then loads the next scene.
	/// </summary>
	/// <param name="name">Name of the next scene.</param>
	public static void LoadAfterLoadingScene(string name)
	{
		nextScene = name;
		SceneManager.LoadScene("Loading");
	}
}
