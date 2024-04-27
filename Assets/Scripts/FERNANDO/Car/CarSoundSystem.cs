using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSoundSystem : MonoBehaviour
{
    [Header("AudioClips")]
    public AudioClip starting;
    public AudioClip rolling;
    public AudioClip stopping;

    [Header("pitch parameter")]
    public float flatoutSpeed = 20.0f;
    [Range(0.0f, 3.0f)]
    public float minPitch = 0.7f;
    [Range(0.0f, 0.1f)]
    public float pitchSpeed = 0.05f;

    [SerializeField]
    private AudioSource source;

    private CarMovementSystem vehicle;

    void Start()
    {
        vehicle = GetComponent<CarMovementSystem>();
    }

    void Update()
    {
        if (vehicle.Handbrake && source.clip == rolling)
        {
            Debug.Log("sfdsfds");
            source.clip = stopping;
            source.Play();
        }

        if (!vehicle.Handbrake && (source.clip == stopping || source.clip == null))
        {
            Debug.Log("sfdsfds");
            source.clip = starting;
            source.Play();

            source.pitch = 1;
        }

        if (!vehicle.Handbrake && !source.isPlaying)
        {
            Debug.Log("sfdsfds");
            source.clip = rolling;
            source.Play();
        }

        if (source.clip == rolling)
        {
            Debug.Log("sfdsfds");
            source.pitch = Mathf.Lerp(source.pitch, minPitch + Mathf.Abs(vehicle.Speed) / flatoutSpeed, pitchSpeed);
        }
    }
}
