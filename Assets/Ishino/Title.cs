using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
	[SerializeField]
	string gameSceneName;

	private void FixedUpdate()
	{
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
		{
			SceneManager.LoadScene(gameSceneName);
		}
	}
}
