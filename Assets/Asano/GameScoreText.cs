using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreText : MonoBehaviour
{

	private void FixedUpdate()
	{
		var PlayScore = Score.instance.GetScore();
		var HighScore = Score.instance.GetHighScore();
		var TextObject = GetComponent<Text>();
		TextObject.text = "“¾“_ : " + PlayScore + "\n";
	}
}
