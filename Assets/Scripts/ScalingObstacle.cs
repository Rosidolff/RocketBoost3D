using UnityEngine;
using DG.Tweening;

public class ScalingObstacle : MonoBehaviour
{
    [SerializeField] private float scaleMultiplier = 1.8f;
    [SerializeField] private float duration = 1.5f;
    [SerializeField] private float delay = 0f;

    void Start()
    {
        // Grow and shrink from the original scale forever
        transform.DOScale(transform.localScale * scaleMultiplier, duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo)
            .SetDelay(delay);
    }
}
