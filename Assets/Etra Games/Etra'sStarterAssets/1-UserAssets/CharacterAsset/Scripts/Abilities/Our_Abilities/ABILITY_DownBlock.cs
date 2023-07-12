using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_DownBlock : EtraAbilityBaseClass
    {
        private Animator _animator;
        private StarterAssetsInputs _input;
        private HealthStatusManager _healthStatusManager;
        bool _hasAnimator;

    public override void abilityStart()
        {
            mainController = GetComponentInParent<EtraCharacterMainController>();
            _input = GetComponentInParent<StarterAssetsInputs>();
            _healthStatusManager = GetComponentInParent<HealthStatusManager>();
            _hasAnimator = EtrasResourceGrabbingFunctions.TryGetComponentInChildren<Animator>(EtraCharacterMainController.Instance.modelParent);
            if (_hasAnimator) {
                _animator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
            }
            Debug.Log("Entra nell'abilità");
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.downBlock = false;
                return;
            }
            if(_hasAnimator)
            {
                _animator.SetBool("DownBlock",_input.downBlock);
                _healthStatusManager.SetStatus("blockDown",_input.block,"player");
            }
        }
    }
