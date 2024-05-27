
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerHealthText;
    [SerializeField] private Image playerHealthImage;
    [SerializeField] private PlayerHealth playerHealth;

    private float duration = 0.1f;
    private float scaleMultiplier = 1.2f;

    private void Awake()
    {
        playerHealth.OnPlayerHealthChanged += PlayerHealth_OnPlayerHealthChanged;
    }

    private void PlayerHealth_OnPlayerHealthChanged()
    {
        Vector3 originalScale = playerHealthImage.transform.localScale;
        Vector3 targetScale = originalScale * scaleMultiplier;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(image.transform.DOScale(targetScale, duration / 2).SetEase(Ease.OutQuad))
                .Append(image.transform.DOScale(originalScale, duration / 2).SetEase(Ease.InQuad))
                .SetLoops(-1, LoopType.Restart);

        playerHealthText.text = playerHealth.currentHealth.ToString();
    }
}
