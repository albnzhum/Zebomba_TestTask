using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    public Image image;

    public float _scaleMultiplier = 1.5f; 
    public float _moveDuration = 0.5f;    
    public float _colorChangeDuration = 0.5f; 
    public Ease _moveEase = Ease.OutBounce;

    private Vector3 _startPosition;
    private Vector3 _startScale;

    private void Start()
    {
        _startPosition = transform.position;
        _startScale = transform.localScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            Color newColor = new Color(Random.value, Random.value, Random.value, Random.value); 
            ScaleAndColor(transform, newColor);
        }
    }

    private void ScaleAndColor(Transform obj, Color color)
    {
        DOTween.Sequence()
            .Append(obj.DOScale(_scaleMultiplier, _moveDuration / 2.0f).SetEase(_moveEase))
            .Append(obj.GetComponent<SpriteRenderer>().DOColor(color, _colorChangeDuration).SetEase(_moveEase))
            .Append(image.DOColor(color, 2f))
            .Append(transform.DOMove(_startPosition, _moveDuration).SetEase(_moveEase))
            .Append(obj.DOScale(_startScale, _moveDuration / 2.0f).SetEase(_moveEase));
    }
}