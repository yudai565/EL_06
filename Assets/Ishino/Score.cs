using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Score : MonoBehaviour
{
    public static Score instance;
    [SerializeField] private List<float> HighScore = default;
    [SerializeField] private float playScore = default;

    // Start is called before the first frame update
    void Start()
    {
        playScore = 0;
    }

    public void AddScore(int add)
    {
        playScore += Mathf.Pow(2, add);
    }

    public void UpdateHighScore()
    {
        HighScore.Add(playScore);
        HighScore.Sort();
    }

    public void ReStartScore()
    {
        playScore = 0;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        CheckInstance();
    }

    void CheckInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public float GetScore()
    {
        return playScore;
    }

    public List<float> GetHighScore()
    {
        return HighScore;
    }
}
