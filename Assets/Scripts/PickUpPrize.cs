using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPrize : MonoBehaviour
{
    private AudioSource _pickSound;
    private ParticleSystem _particles;
    private ScoreManager _theScoreManager;

    private void Start()
    { 
        _pickSound = GameObject.Find("Player").GetComponents<AudioSource>()[0];
        _particles = GameObject.Find("Player").GetComponentInChildren<ParticleSystem>();
        _theScoreManager = FindObjectOfType<ScoreManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            _pickSound.Play();
            Destroy(gameObject);
            _particles.Play();
            _theScoreManager.UpdateScore(10);
        }
    }
}
