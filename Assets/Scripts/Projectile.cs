using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 2f;

    [SerializeField] private float projectileHealth = 200f;
    [SerializeField] private float damage = 100f;

    // Update is called once per frame
    void Update()
    {
        MoveProjectile();
    }

    private void MoveProjectile()
    {
        transform.Translate(Vector2.right * (projectileSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();

        if (!health || !attacker) return;
        health.DealDamage(damage);

        DestroyProjectile();
    }

    private void DestroyProjectile()
    {
        projectileHealth -= damage;
        if (projectileHealth <= 0)
            Destroy(gameObject);
    }
}