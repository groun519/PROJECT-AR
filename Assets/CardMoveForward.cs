using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMoveForward : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5.0f;
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private TFAnimtion attacker;

    [SerializeField]
    private float DestryTime = 5.0f;

    [SerializeField]
    private AudioClip ShootSoundClip;
    private AudioSource ShootSound;

    void Start()
    {
        ShootSound = gameObject.AddComponent<AudioSource>();
        ShootSound.pitch = Random.Range(10, 20) / 10;
        ShootSound.clip = ShootSoundClip;
        ShootSound.Play();
        Destroy(gameObject, DestryTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<TargetMonster>();
            if (enemy != null)
            {
                enemy.ApplyDamage(damage);
                attacker.ComboStack += damage;
                Destroy(this.gameObject);
            }
        }
    }
}
