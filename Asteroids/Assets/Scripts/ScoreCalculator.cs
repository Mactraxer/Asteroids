using UnityEngine;
using UnityEngine.UI;

public interface IScoreEventInput
{
    public void AddScore(int count);

}
public class ScoreCalculator : MonoBehaviour
{

    [SerializeField]
    Text scoreText;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Очки: ";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateScoreText()
    {
        scoreText.text = $"Очки: {score}";
    }

    public void AddScore(int count)
    {
        score += count;
        UpdateScoreText();
    }

    public int GetScore()
    {
        return score;
    }

}
