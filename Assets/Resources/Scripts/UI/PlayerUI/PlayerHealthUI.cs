using TMPro;
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

    private void Start()
    {
        playerHealth.OnPlayerHealthChanged += PlayerHealth_OnPlayerHealthChanged;
        PlayerHealth_OnPlayerHealthChanged();
    }

    private void PlayerHealth_OnPlayerHealthChanged()
    {
        Vector3 originalScale = playerHealthImage.transform.localScale;
        Vector3 targetScale = originalScale * scaleMultiplier;

        Sequence sequence = DOTween.Sequence();
        sequence.Append(playerHealthImage.transform.DOScale(targetScale, duration / 2).SetEase(Ease.OutQuad))
                .Append(playerHealthImage.transform.DOScale(originalScale, duration / 2).SetEase(Ease.InQuad));

        playerHealthText.text = playerHealth.currentHealth.ToString();
    }
}
