using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_Kick : EtraAbilityBaseClass
    {
        private Animator _animator;
        private StarterAssetsInputs _input;
        bool _hasAnimator;

    public override void abilityStart()
        {
            mainController = GetComponentInParent<EtraCharacterMainController>();
            _input = GetComponentInParent<StarterAssetsInputs>();
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
                _input.kick=false;
            }
        }
    }