using System.Collections.Generic;
using UnityEngine;

public class Root : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    [SerializeField]
    private SpriteRenderer _background;

    [SerializeField]
    private CharacterView _characterView;

    [SerializeField]
    private SpriteAnimationConfig _spriteAnimationConfig;

    [SerializeField]
    private Enemy _enemyView;

    [SerializeField]
    private List<BulletView> _bullets;

    private ParalaxManager _paralaxManager;
    private SpriteAnimator _spriteAnimator;
    private MainHeroWalker _mainHeroWalker;
    private MainHeroPhysicsWalker _mainHeroPhysicsWalker;
    private AimingMuzzle _aimingMuzzle;
    private BulletsEmitter _bulletsEmitter;

    private void Start()
    {
        _paralaxManager = new ParalaxManager(_camera, _background.transform);
        _spriteAnimator = new SpriteAnimator(_spriteAnimationConfig);
        _mainHeroPhysicsWalker = new MainHeroPhysicsWalker(_characterView, _spriteAnimator);
        _aimingMuzzle = new AimingMuzzle(_enemyView.transform, _characterView.transform);
        _bulletsEmitter = new BulletsEmitter(_bullets, _enemyView.MuzzleTransform);
    }

    private void Update()
    {
        _paralaxManager.Update();
        _spriteAnimator.Update();
        _aimingMuzzle.Update();
        _bulletsEmitter.Update();
    }

    private void FixedUpdate()
    {
        _mainHeroPhysicsWalker.FixedUpdate();
    }

    private void OnDestroy()
    {

    }
}