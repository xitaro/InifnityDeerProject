using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // The player's score
    // With multiplayer it can't be static
    public static int score;

    // Reference to the TextMeshPro component.
    private TMP_Text scoreText;                      

    void Awake()
    {
        // Set up the TextMeshPro reference
        scoreText = GameObject.Find("ScoreText (TMP)").GetComponent<TMP_Text>();

        // Reset the score
        score = 0;
    }

    void Update()
    {
        // Set the displayed text to be the word "Score" followed by the score value
        scoreText.text = "SCORE: " + score;
    }
}
