using UnityEngine;
using DG.Tweening;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float duration = 2f;
    [SerializeField] private Vector3 rotationDirection = new Vector3(0, 0, 90);

    void Start()
    {
        transform.DOLocalRotate(rotationDirection, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Incremental);
    }
}