using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Score score = default;
    private List<float> HighScore = default;
    private float PlayScore = default;
    [SerializeField] Text TextObject = default;
    [SerializeField] string titleSceneName;



    // Start is called before the first frame update
    void Start()
    {
        score = Score.instance;
        PlayScore = score.GetScore();
        HighScore = score.GetHighScore();
        HighScore.Sort();
        DisplayScore();
    }



	private float nowTime = 0f;
	private void FixedUpdate()
	{
        if (nowTime > 2f)
        {
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
			{
				SceneManager.LoadScene(titleSceneName);
			}
		}

        nowTime += Time.deltaTime;
	}

	void DisplayScore()
    {
        TextObject.text = "  今回の得点  : " + PlayScore   + "\n";
        for (int n = 1; n <= 5 && n < HighScore.Count; n++)
            TextObject.text += "ハイスコア(" + n + ") : " + HighScore[HighScore.Count - (n)] + "\n";
    }
}
