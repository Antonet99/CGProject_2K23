using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_Throw : EtraAbilityBaseClass
    {
    private Animator _animator,_enemyAnimator;
    private Transform parentTransform;
    private StarterAssetsInputs _input;
    bool _hasAnimator, _areNear;
    public GameObject enemy;
    private Vector3 currentRotation;
    private Quaternion newRotation;
    private HealthStatusManager _healthStatusManager;
    private ABILITY_CharacterMovement _characterMovement;

    public override void abilityStart()
        {
            mainController = GetComponentInParent<EtraCharacterMainController>();
            _input = GetComponentInParent<StarterAssetsInputs>();
            _healthStatusManager = GetComponentInParent<HealthStatusManager>();
            _hasAnimator = EtrasResourceGrabbingFunctions.TryGetComponentInChildren<Animator>(EtraCharacterMainController.Instance.modelParent);
            if (_hasAnimator) {
                _animator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
            }
            _enemyAnimator = enemy.GetComponentInChildren<Animator>();
            if (EtraCharacterMainController.Instance.etraAbilityManager.GetComponent<ABILITY_CharacterMovement>() != null)
            {
                _characterMovement = EtraCharacterMainController.Instance.etraAbilityManager.GetComponent<ABILITY_CharacterMovement>();
            }
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.throwenemy = false;
                return;
            }
            if (_hasAnimator && _input.throwenemy==true){
                parentTransform=transform.parent;
                float difference = Mathf.Abs(parentTransform.position.x-enemy.transform.position.x);
                _areNear=(difference<=2f&&difference>=1f)?true:false;
                Debug.Log(difference);

                if(_areNear)
                {
                    _enemyAnimator.Play("Wait");
                    _characterMovement.distanceAmong=0;
                    _characterMovement.enabled=false;
                    _animator.Play("PressUpThrow_Att");
                    _enemyAnimator.Play("PressUpThrow_Vic");
                    _healthStatusManager.takeDamage(6,"enemy","throw");
                    _healthStatusManager.ResizeBar(_healthStatusManager.enemyLife,_healthStatusManager.enemyBarTransform);
                }
                _input.throwenemy=false;

            }
        }
    }


