using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private Transform respawn;
    private AudioSource _damageNoise;

    private void Start()
    {
        _damageNoise = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Hazard"))
        {
            _damageNoise.PlayOneShot(_damageNoise.clip);
            transform.position = respawn.transform.position;
        }
        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            respawn = other.transform;
        }
    }
}
