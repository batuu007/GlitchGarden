using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    private float _currentSpeed = 1f;
    private string _isAttacking = "isAttacking";
    private GameObject _currentTarget;
    private Animator _animator;


    // Update is called once per frame
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        MoveAttacker();
        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!_currentTarget)
        {
            _animator.SetBool(_isAttacking, false);
        }
    }

    private void MoveAttacker()
    {
        transform.Translate(Vector2.left * (_currentSpeed * Time.deltaTime));
    }

    //using in animator
    public void SetAttackerMoveSpeed(float speed)
    {
        _currentSpeed = speed;
    }

    public void Attack(GameObject target)
    {
        _animator.SetBool(_isAttacking, true);
        _currentTarget = target;
    }

    public void StrikeCurrentTarget(float damage)
    {
        if (!_currentTarget) return;
        Health health = _currentTarget.GetComponent<Health>();
        if (health)
            health.DealDamage(damage);
    }
}