using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject deathVFX;
    private float _deathVFXDuration = 1f;

    public void DealDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            TriggerDeathVFX();
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) return;

        GameObject deathVFXGameObject = Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(deathVFXGameObject, _deathVFXDuration);
    }
}