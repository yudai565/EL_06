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
        TextObject.text = "  ����̓��_  : " + PlayScore   + "\n";
        for (int n = 1; n <= 5 && n < HighScore.Count; n++)
            TextObject.text += "�n�C�X�R�A(" + n + ") : " + HighScore[HighScore.Count - (n)] + "\n";
    }
}
