using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gun;
    private AttackerSpawner _myLaneSpawner;

    private Animator _animator;
    private string _isAttacking = "isAttacking";

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetIsAttacking();
    }

    private void SetIsAttacking()
    {
        if (IsAttackerInLane())
            _animator.SetBool(_isAttacking, true);
        else
            _animator.SetBool(_isAttacking, false);
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough =
                (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (isCloseEnough)
                _myLaneSpawner = spawner;
        }
    }

    private bool IsAttackerInLane()
    {
        if (_myLaneSpawner.transform.childCount <= 0)
            return false;

        return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, Quaternion.identity);
        newProjectile.transform.parent = transform;
    }
}