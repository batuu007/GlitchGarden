using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] private float minSpawnDelay = 1f;
    [SerializeField] private float maxSpawnDelay = 5f;
    [SerializeField] private Attacker[] attacker;

    private Vector2 _attackerPosition;
    private float _positionX;
    private float _positionY;
    private float _attackerPositionY = 0.35f;

    private bool _spawn = true;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        _positionX = transform.position.x;
        _positionY = transform.position.y + _attackerPositionY;
        _attackerPosition = new Vector2(_positionX, _positionY);

        while (_spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    private void SpawnAttacker()
    {
        int attackerIndex = Random.Range(0, attacker.Length);
        Spawn(attacker[attackerIndex]);
    }

    private void Spawn(Attacker attacker)
    {
        Attacker newAttacker = Instantiate(attacker, _attackerPosition, Quaternion.identity);
        newAttacker.transform.parent = transform;
    }
}