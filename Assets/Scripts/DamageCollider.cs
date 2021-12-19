using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    [SerializeField] private LiveDisplay liveDisplay;

    private void OnTriggerEnter2D(Collider2D other)
    {
        liveDisplay.TakeLife();
        Destroy(other.gameObject);
    }
}