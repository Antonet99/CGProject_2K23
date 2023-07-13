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
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.throwenemy = false;
                return;
            }
            if (_hasAnimator && _input.throwenemy==true){
                parentTransform=transform.parent;
                _areNear=Vector3.Distance(parentTransform.position,enemy.transform.position)<=2f?true:false;
                
                if(_areNear && !_healthStatusManager.GetStatus("block","enemy") && !_healthStatusManager.GetStatus("blockDown","enemy")){
                    _animator.SetTrigger("Press");
                    _enemyAnimator.SetTrigger("Throw");
                    _healthStatusManager.takeDamage(6,"enemy","throw");
                    _healthStatusManager.ResizeBar(_healthStatusManager.enemyLife,_healthStatusManager.enemyBarTransform);
                }
                _input.throwenemy=false;
            }
        }
    }


