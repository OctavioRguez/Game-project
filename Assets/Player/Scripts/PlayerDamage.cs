using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{

	public float maxHealth = 100f, currentHealth;
	private int cont = 1;

	[SerializeField]private HealthBar healthBar;
	[SerializeField]private PauseMenu Menu;

    // Start is called before the first frame update
    void Start()
    {
		if (cont > 0)
		{
			currentHealth = maxHealth;
			healthBar.MaxHealth(maxHealth);
			cont -= 1;
		}
		healthBar.Start();
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetKeyDown(KeyCode.Z))
		{
			Damage(20);
			healthBar.DamageEffect.Play();
			healthBar.DamageEffect2.Play();
		}
		else if (Input.GetKeyDown(KeyCode.X))
		{
			Heal(20);
		}

		if (currentHealth == 0)
		{
			Menu.Die = true;
			currentHealth = 0.1f;
		}
    }

	void Damage(float damage)
	{
		currentHealth -= damage;
		healthBar.Health(currentHealth);
		Invoke("Start", 2);
	}

	void Heal(float damage)
	{
		if (currentHealth != maxHealth)
		{
			currentHealth += damage;
			healthBar.Health(currentHealth);
			Invoke("Start", 0);
		}
	}
}
