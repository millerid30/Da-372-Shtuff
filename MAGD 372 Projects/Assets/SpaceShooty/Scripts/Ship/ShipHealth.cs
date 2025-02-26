using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public abstract class ShipHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float health;
    [SerializeField] protected float maxHealth;
    [SerializeField] private bool VanishAtFull;
    [SerializeField] private Image healthBar;
    public ShipHealth(float maxHealth)
    {
        PlayerHealth = maxHealth;
    }
    public float PlayerHealth
    {
        get => maxHealth;
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Health must be greater than 0", nameof(PlayerHealth));
            }
            maxHealth = value;
        }
    }
    void Start()
    {
        health = maxHealth;
    }
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (VanishAtFull)
        {
            if (health / maxHealth > 0)
            {
                healthBar.gameObject.SetActive(false);
            }
            else
            {
                healthBar.gameObject.SetActive(true);
            }
        }
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        // TEST damage/heal
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Damage(20);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }
    public void Heal(float heal)
    {
        health += heal;
        health = Mathf.Clamp(health, 0, maxHealth);
    }
    public void Damage(float damage)
    {
        health -= damage;
    }
}