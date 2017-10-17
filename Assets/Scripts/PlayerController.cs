using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    private Rigidbody2D _playerRigidbody;
    private BoxCollider2D _playerCollider;
    public LayerMask GroundLayer;
    public bool IsGrounded;
    private Animator _playerAnimator;
    private GameManager _theGameManager;
    private AudioSource _lostLifeSound;

    private void Awake()
    {
        _playerRigidbody = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<BoxCollider2D>();
        _playerAnimator = GetComponent<Animator>();
        _theGameManager = FindObjectOfType<GameManager>();
        _lostLifeSound = GetComponents<AudioSource>()[1];
    }
	
	private void FixedUpdate ()
    {
		_playerRigidbody.velocity = new Vector2(Speed, _playerRigidbody.velocity.y);

        if (Input.GetKey(KeyCode.Space) && IsGrounded)
        {
            _playerRigidbody.velocity = new Vector2(_playerRigidbody.velocity.x, JumpForce);
        }

        IsGrounded = Physics2D.IsTouchingLayers(_playerCollider, GroundLayer);
        _playerAnimator.SetBool("Grounded", IsGrounded);

        if (transform.position.y < -6)
        {
            _lostLifeSound.Play();
            _theGameManager.LifeLost();
            transform.position = new Vector3(transform.position.x, 5, transform.position.z);
        }
    }
}
