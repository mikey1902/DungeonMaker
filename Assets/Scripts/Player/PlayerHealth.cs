using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	private float health;
	private float lerpTime;

	[Header("Health Bar")]
	public float maxHealth = 100f;
	public float healthChipSpeed = 2f;
	public Image frontHealthBar;
	public Image chipHealthBar;

	[Header("DamageEffect")]
	public Image damageOverlay;
	public float effectDuration;
	public float effectFadeSpeed;

	private float durationTimer;

	void Start()
	{
		health = maxHealth;
		damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Y))
		{
			TakeDamage(10);
		}
		if (Input.GetKeyDown(KeyCode.U))
		{
			RestoreHealth(10);
		}

		health = Mathf.Clamp(health, 0, maxHealth);
		UpdateHealthBar();
		if (damageOverlay.color.a > 0)
		{
			if (health < 30)
				return;
			durationTimer += Time.deltaTime;
			if (durationTimer > effectDuration)
			{
				float tempAlpha = damageOverlay.color.a;
				tempAlpha -= Time.deltaTime * effectFadeSpeed;
				damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAlpha);
			}
		}
	}

	public void UpdateHealthBar()
	{
		float fillFront = frontHealthBar.fillAmount;
		float fillChip = chipHealthBar.fillAmount;
		float healthPercent = health / maxHealth;

		if (fillChip > healthPercent)
		{
			frontHealthBar.fillAmount = healthPercent;
			chipHealthBar.color = Color.white;
			lerpTime += Time.deltaTime;

			float percentChipProgress = lerpTime / healthChipSpeed;
			percentChipProgress *= percentChipProgress;
			chipHealthBar.fillAmount = Mathf.Lerp(fillChip, healthPercent, percentChipProgress);
		}

		if (fillFront < healthPercent)
		{
			chipHealthBar.fillAmount = healthPercent;
			chipHealthBar.color = Color.green;
			lerpTime += Time.deltaTime;

			float percentChipProgress = lerpTime / healthChipSpeed;
			percentChipProgress *= percentChipProgress;
			frontHealthBar.fillAmount = Mathf.Lerp(fillFront, fillChip, percentChipProgress);
		}
	}

	public void TakeDamage(float damage)
	{
		health -= damage;
		lerpTime = 0f;
		durationTimer = 0f;
		damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
	}

	public void RestoreHealth(float heal)
	{
		health += heal;
		lerpTime = 0f;
	}
}
