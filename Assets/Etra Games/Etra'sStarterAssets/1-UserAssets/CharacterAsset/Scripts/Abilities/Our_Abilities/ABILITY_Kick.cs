using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_Kick : EtraAbilityBaseClass
    {
        private Animator _animator;
        private StarterAssetsInputs _input;
        bool _hasAnimator, _areNear;
        public GameObject enemy;
        private Transform parentTransform;
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
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.kick = false;
                return;
            }
            if (_hasAnimator && _input.kick==true){
                Debug.Log("calcio");
                _animator.SetTrigger("Kick");
                 parentTransform=transform.parent;
                _areNear=(parentTransform.position.x-enemy.transform.position.x)<=1.2f?true:false;
                if(_areNear)
                {
                    _healthStatusManager.takeDamage(3,"enemy","kick");
                    _healthStatusManager.ResizeBar(_healthStatusManager.enemyLife,_healthStatusManager.enemyBarTransform);
                }
                _input.kick=false;
            }
        }
    }