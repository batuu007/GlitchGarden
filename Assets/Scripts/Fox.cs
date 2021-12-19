using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker _attacker;
    private string _jumpTrigger = "jumpTrigger";

    private void Start()
    {
        _attacker = GetComponent<Attacker>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject otherObject = other.gameObject;

        if (otherObject.GetComponent<Gravestone>())
            GetComponent<Animator>().SetTrigger(_jumpTrigger);
        else if (otherObject.GetComponent<Defender>())
            _attacker.Attack(otherObject);
    }
}