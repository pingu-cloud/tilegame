using UnityEngine;
using DG.Tweening;

public class FallingAndRandomFloatingY : MonoBehaviour
{
    private Vector3 initialPosition; // To store the initial position

    [SerializeField] private float fallHeight = 5f; // Height from which the object will fall
    [SerializeField] private float fallDuration = 1f; // Duration of the fall animation
    [SerializeField] private float floatAmplitude = 0.5f; // Maximum Y offset for random floating
    [SerializeField] private float floatDuration = 2f; // Duration of one random floating cycle

    private void OnEnable()
    {
        // Stop any existing animations to reset properly
        DOTween.Kill(transform);

        // Store the initial position (if not already set)
        if (initialPosition == Vector3.zero)
        {
            initialPosition = transform.position;
        }

        // Set the starting position above the initial position
        transform.position = initialPosition + Vector3.up * fallHeight;

        // Create a DOTween sequence for the animations
        Sequence sequence = DOTween.Sequence();

        // Add the fall animation to the sequence
        sequence.Append(transform.DOMove(initialPosition, fallDuration)
            .SetEase(Ease.OutBounce));

        // Add the random floating animation
        sequence.AppendCallback(StartRandomFloating);
    }

    private void StartRandomFloating()
    {
        PerformRandomFloat();
    }

    private void PerformRandomFloat()
    {
        // Calculate a new random Y position within the amplitude range
        float randomYOffset = Random.Range(-floatAmplitude, floatAmplitude);

        // Target position with random Y offset
        Vector3 targetPosition = new Vector3(initialPosition.x, initialPosition.y + randomYOffset, initialPosition.z);

        // Animate to the random Y position
        transform.DOMoveY(targetPosition.y, floatDuration)
            .SetEase(Ease.InOutSine)
            .OnComplete(PerformRandomFloat); // Repeat animation on completion
    }
}
