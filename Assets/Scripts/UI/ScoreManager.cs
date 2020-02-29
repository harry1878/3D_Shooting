using UnityEngine;
using UnityEngine.UI;

class ScoreManager : MonoBehaviour
{
    public Text text;
    private int score;

    private void Awake()
    {
        score = 0;
    }

    private static ScoreManager instance = null;
    public static ScoreManager Get
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ScoreManager>();

            return instance;
        }
    }

    public int Score
    {
        get { return score; }
        set
        {
            score += value;
            text.text = "Score :" + score.ToString();
        }
    }
}