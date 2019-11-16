﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Player
{
	public class PlayerController : MonoBehaviour
	{
		[FormerlySerializedAs("m_JumpForce")] [SerializeField] private float mJumpForce = 400f;							// Amount of force added when the player jumps.
		[FormerlySerializedAs("m_CrouchSpeed")] [Range(0, 1)] [SerializeField] private float mCrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
		[FormerlySerializedAs("m_RunSpeed")] [Range(1, 100)] [SerializeField] private float mRunSpeed = 40f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
		[FormerlySerializedAs("m_MovementSmoothing")] [Range(0, .3f)] [SerializeField] private float mMovementSmoothing = .05f;	// How much to smooth out the movement
		[FormerlySerializedAs("m_AirControl")] [SerializeField] private bool mAirControl = false;							// Whether or not a player can steer while jumping;
		[FormerlySerializedAs("m_WhatIsGround")] [SerializeField] private LayerMask mWhatIsGround;							// A mask determining what is ground to the character
		[FormerlySerializedAs("m_GroundCheck")] [SerializeField] private Transform mGroundCheck;							// A position marking where to check if the player is grounded.
		[FormerlySerializedAs("m_CeilingCheck")] [SerializeField] private Transform mCeilingCheck;							// A position marking where to check for ceilings
		[FormerlySerializedAs("m_CrouchDisableCollider")] [SerializeField] private Collider2D mCrouchDisableCollider;				// A collider that will be disabled when crouching

		private const float KGroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
		private bool _mGrounded;            // Whether or not the player is grounded.
		private const float KCeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
		private Rigidbody2D _mRigidbody2D;
		private bool _mFacingRight = true;  // For determining which way the player is currently facing.
		private Vector3 _mVelocity = Vector3.zero;

		[FormerlySerializedAs("OnLandEvent")]
		[Header("Events")]
		[Space]

		public UnityEvent onLandEvent;

		[System.Serializable]
		public class BoolEvent : UnityEvent<bool> { }

		[FormerlySerializedAs("OnCrouchEvent")] public BoolEvent onCrouchEvent;
		private bool _mWasCrouching = false;

		private float _horizontalMove = 0f;
		private bool _jump = false;
	
		private void Awake()
		{
			_mRigidbody2D = GetComponent<Rigidbody2D>();

			if (onLandEvent == null)
				onLandEvent = new UnityEvent();

			if (onCrouchEvent == null)
				onCrouchEvent = new BoolEvent();
		}

		void Update () {

			_horizontalMove = Input.GetAxisRaw("Horizontal") * mRunSpeed;

			if (Input.GetButtonDown("Jump")) _jump = true;

			if (Input.GetButtonDown("Crouch")) _mWasCrouching = true;
			else if (Input.GetButtonUp("Crouch")) _mWasCrouching = false;
		}
	
		private void FixedUpdate()
		{
			// Move our character
			Move(_horizontalMove * Time.fixedDeltaTime, _mWasCrouching, _jump);
			_jump = false;
		
			var wasGrounded = _mGrounded;
			_mGrounded = false;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(mGroundCheck.position, KGroundedRadius, mWhatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					_mGrounded = true;
					if (!wasGrounded)
						onLandEvent.Invoke();
				}
			}
		}
		
		public void Move(float move, bool crouch, bool jump)
		{
			// If crouching, check to see if the character can stand up
			if (!crouch)
			{
				// If the character has a ceiling preventing them from standing up, keep them crouching
				if (Physics2D.OverlapCircle(mCeilingCheck.position, KCeilingRadius, mWhatIsGround))
				{
					crouch = true;
				}
			}

			//only control the player if grounded or airControl is turned on
			if (_mGrounded || mAirControl)
			{

				// If crouching
				if (crouch)
				{
					if (!_mWasCrouching)
					{
						_mWasCrouching = true;
						onCrouchEvent.Invoke(true);
					}

					// Reduce the speed by the crouchSpeed multiplier
					move *= mCrouchSpeed;

					// Disable one of the colliders when crouching
					if (mCrouchDisableCollider != null)
						mCrouchDisableCollider.enabled = false;
				} else
				{
					// Enable the collider when not crouching
					if (mCrouchDisableCollider != null)
						mCrouchDisableCollider.enabled = true;

					if (_mWasCrouching)
					{
						_mWasCrouching = false;
						onCrouchEvent.Invoke(false);
					}
				}

				// Move the character by finding the target velocity
				Vector3 targetVelocity = new Vector2(move * 10f, _mRigidbody2D.velocity.y);
				// And then smoothing it out and applying it to the character
				_mRigidbody2D.velocity = Vector3.SmoothDamp(_mRigidbody2D.velocity, targetVelocity, ref _mVelocity, mMovementSmoothing);

				// If the input is moving the player right and the player is facing left...
				if (move > 0 && !_mFacingRight)
				{
					// ... flip the player.
					Flip();
				}
				// Otherwise if the input is moving the player left and the player is facing right...
				else if (move < 0 && _mFacingRight)
				{
					// ... flip the player.
					Flip();
				}
			}
			// If the player should jump...
			if (_mGrounded && jump)
			{
				// Add a vertical force to the player.
				_mGrounded = false;
				_mRigidbody2D.AddForce(new Vector2(0f, mJumpForce));
			}
		}


		private void Flip()
		{
			// Switch the way the player is labelled as facing.
			_mFacingRight = !_mFacingRight;

			// Multiply the player's x local scale by -1.
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}
}