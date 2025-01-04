using UnityEngine;
using TMPro; // Required for TextMeshPro
using DG.Tweening; // Required for DOTween animations

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText; // Reference to the TextMeshPro text
    public int scorechange = 5; // Public score with a default value of 5
    [SerializeField] private float bounceScale = 1.2f; // Scale for the bounce effect
    [SerializeField] private float bounceDuration = 0.3f; // Duration of the bounce animation
    private int score = 0;
    private void Start()
    {
        // Initialize the score text
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        // Increase the score
        score += scorechange;

        // Update the score text
        UpdateScoreText();

        // Play the bouncy text animation
        AnimateTextBounce();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }

    private void AnimateTextBounce()
    {
        if (scoreText != null)
        {
            // Reset any existing animations on the text
            DOTween.Kill(scoreText.transform);

            // Animate the text with a bounce effect
            scoreText.transform.DOScale(bounceScale, bounceDuration / 2)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    scoreText.transform.DOScale(1f, bounceDuration / 2).SetEase(Ease.InQuad);
                });
        }
    }
}
