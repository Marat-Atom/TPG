﻿//Copyright Ex/IO 2020
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class AudioManager : MonoBehaviour
{
    public List<AudioClip> stepSounds;
    public List<AudioClip> enemySoulHit;
    public List<AudioClip> enemyRangeSoulShoot;
    public List<AudioClip> doorOpens;
    public List<AudioClip> pickUp;


    void Awake ()
    {
        EventAudio.damageEnemySoul.AddListener(EnemyDamaged);
        EventAudio.playerStepSound.AddListener(PlayerStep);
        EventAudio.rangeSoulShoot.AddListener(RangeSoulShoot);
        EventAudio.doorOpens.AddListener(DoorOpens);
        EventAudio.pickUp.AddListener(PickUp);
    }



    void PlayerStep()
    {
        GameManager.instance.playerManager.GetComponent<AudioSource>().PlayOneShot(stepSounds[Random.Range(0, stepSounds.Count)]);
    }

    void EnemyDamaged(AudioSource _source)
    {
        _source.PlayOneShot(enemySoulHit[Random.Range(0, enemySoulHit.Count)]);
    }

    void RangeSoulShoot(AudioSource _source)
    {
        _source.PlayOneShot(enemyRangeSoulShoot[Random.Range(0, enemyRangeSoulShoot.Count)]);
    }

    void DoorOpens(AudioSource _source)
    {
        _source.PlayOneShot(doorOpens[Random.Range(0, doorOpens.Count)]);
    }

    void PickUp (AudioSource _source)
    {
        _source.PlayOneShot(pickUp[Random.Range(0, pickUp.Count)]);
    }
}

[System.Serializable]
public static class EventAudio
{
    public static PlayerStepSound playerStepSound = new PlayerStepSound();

    public static DoorOpens doorOpens = new DoorOpens();

    public static PickUp pickUp = new PickUp();

    public static DamagePlayer damagePlayer = new DamagePlayer();
    public static DamageEnemySoul damageEnemySoul = new DamageEnemySoul();
    public static RangeSoulShoot rangeSoulShoot = new RangeSoulShoot();
}

public class PlayerStepSound : UnityEvent { }

public class DoorOpens : UnityEvent<AudioSource> { }
public class PickUp : UnityEvent<AudioSource> { }

public class DamagePlayer : UnityEvent<int, float> { }
public class DamageEnemySoul : UnityEvent<AudioSource> { }
public class RangeSoulShoot : UnityEvent<AudioSource> { }
