using UnityEngine;
using DG.Tweening;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] private Vector3 movement = new Vector3(0, 3, 0);
    [SerializeField] private float duration = 2f;
    [SerializeField] private float delay = 0f;

    void Start()
    {
        // Start the movement sequence
        transform.DOLocalMove(transform.localPosition + movement, duration)
            .SetEase(Ease.InOutSine) // Smooth easing for the movement
            .SetLoops(-1, LoopType.Yoyo) // Loop indefinitely with a Yoyo effect
            .SetDelay(delay); // Optional delay before starting
    }
}
