using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
	public Slider slider, Backslider;
	public Gradient gradient;
	public Image fill;
	public ParticleSystem DamageEffect, DamageEffect2;

	public void Start()
	{
		Backslider.value = slider.value;
	}

	public void MaxHealth(float health)
	{
		slider.maxValue = health;
		slider.value = health;
		fill.color = gradient.Evaluate(1f);
	}

    public void Health(float health)
	{
		DamageEffect.startColor = gradient.Evaluate(slider.normalizedValue);
		DamageEffect2.startColor = gradient.Evaluate(slider.normalizedValue);
		slider.value = health;
		fill.color = gradient.Evaluate(slider.normalizedValue);
	}
}
