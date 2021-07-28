using UnityEngine;
using UnityEngine.UI;

public class SpaceShipCollision : MonoBehaviour
{

    [SerializeField]
    Text gameOverMessage;
    [SerializeField]
    GameObject gameOverPanel;

    ScoreCalculator eventDelegate;

    // Start is called before the first frame update
    void Start()
    {
        eventDelegate = GameObject.Find("ScoreText").GetComponent<ScoreCalculator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ObjectTag.Enemy)
        {
            EndGame();
        }    
    }

    private void EndGame()
    {
        Time.timeScale = 0.0f;
        UpdateGameOverMessageText($"Ваш корабль разбился, Вы набрали {eventDelegate.GetScore()} баллов");
        gameOverPanel.SetActive(true);
    }

    private void UpdateGameOverMessageText(string text)
    {
        gameOverMessage.text = text;
    }

}
