using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    [SerializeField] private Score score = default;
    private List<float> HighScore = default;
    private float PlayScore = default;
    [SerializeField] Text TextObject = default;

    // Start is called before the first frame update
    void Start()
    {
        PlayScore = score.GetScore();
        HighScore = score.GetHighScore();
        HighScore.Sort();
        DisplayScore();
    }

    void DisplayScore()
    {
        TextObject.text = "  今回の得点  : " + PlayScore   + "\n";
        for (int n = 1; n <= 5 && n < HighScore.Count; n++)
            TextObject.text += "ハイスコア(" + n + ") : " + HighScore[HighScore.Count - (n)] + "\n";
    }
}
