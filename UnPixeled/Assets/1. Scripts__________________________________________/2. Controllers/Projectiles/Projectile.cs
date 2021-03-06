﻿//Copyright Ex/IO 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public bool defendedProjectileByPlayer = false;
    [HideInInspector] public float damage;
    public GameObject particleSystemTrail;



    private void Update()
    {
        if (defendedProjectileByPlayer)
            GetComponent<Rigidbody>().AddForce(transform.forward * -2000);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            EventGame.playerStatAction.Invoke("remove", "health", damage);
            Destroy(gameObject);
        }
        else
            Destroy(gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon")
        {
            if (GameManager.instance.playerManager.defenceState)
            {
                defendedProjectileByPlayer = true;
                GetComponent<Rigidbody>().AddForce(transform.forward * -3000);
                particleSystemTrail.transform.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if (other.gameObject.tag == "Enemy" && defendedProjectileByPlayer)
        {
            other.gameObject.GetComponent<HealthStats_actor>().HealthDamage(damage);
            Destroy(gameObject);
        }
    }
}

