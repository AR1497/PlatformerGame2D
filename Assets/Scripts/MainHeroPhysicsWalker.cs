using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHeroPhysicsWalker
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    private CharacterView _characterView;
    private SpriteAnimator _spriteAnimator;
    private ContactPoller _contactPoller;

    public MainHeroPhysicsWalker(CharacterView characterView, SpriteAnimator spriteAnimator)
    {
        _characterView = characterView;
        _spriteAnimator = spriteAnimator;

        _contactPoller = new ContactPoller(characterView.Collider);
    }

    public void FixedUpdate()
    {
        var doJump = Input.GetAxis(Vertical) > 0;
        var xAxisInput = Input.GetAxis(Horizontal);

        _contactPoller.Update();

        var isGoSideWay = Mathf.Abs(xAxisInput) > _characterView.MovingTresh;

        if (isGoSideWay)
            _characterView.SpriteRenderer.flipX = xAxisInput < 0;

        var newVelocity = 0f;

        if (isGoSideWay && (xAxisInput > 0 || !_contactPoller.HasLeftContacts) && (xAxisInput < 0 || !_contactPoller.HasRightContacts))
        {
            newVelocity = Time.fixedDeltaTime * _characterView.WalkSpeed * (xAxisInput < 0 ? -1 : 1);
        }

        _characterView.Rigidbody2D.velocity = _characterView.Rigidbody2D.velocity.Change(x: newVelocity);

        if (_contactPoller.IsGrounded && doJump && Mathf.Abs(_characterView.Rigidbody2D.velocity.y) <= _characterView.FlyTresh)
            _characterView.Rigidbody2D.AddForce(Vector2.up * _characterView.JumpStartSpeed);

        if (_contactPoller.IsGrounded)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, isGoSideWay ? Track.walk : Track.idle, true,
                _characterView.AnimationsSpeed);
        }
        else if (Mathf.Abs(_characterView.Rigidbody2D.velocity.y) > _characterView.FlyTresh)
        {
            _spriteAnimator.StartAnimation(_characterView.SpriteRenderer, Track.jump, true,
                _characterView.AnimationsSpeed);
        }
    }
}
