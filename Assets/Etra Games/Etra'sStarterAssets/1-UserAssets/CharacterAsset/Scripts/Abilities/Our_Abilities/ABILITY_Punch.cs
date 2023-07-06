using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_Punch : EtraAbilityBaseClass
    {
        private Animator _animator;
        private StarterAssetsInputs _input;
        bool _hasAnimator;
        //bool canPunch = true;
        private int _animIDPunch;
        //public float PunchTimeout = 0.05f;
        //private float _punchTimeoutDelta;

    public override void abilityStart()
        {
            mainController = GetComponentInParent<EtraCharacterMainController>();
            _input = GetComponentInParent<StarterAssetsInputs>();
            _hasAnimator = EtrasResourceGrabbingFunctions.TryGetComponentInChildren<Animator>(EtraCharacterMainController.Instance.modelParent);
            if (_hasAnimator) {
                _animator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
                //_animIDPunch = Animator.StringToHash("Punch");
            }
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.punch = false;
                return;
            }
            if (_hasAnimator && _input.punch==true){
                Debug.Log("è entrato");
                _animator.SetTrigger("Punch");
                _input.punch=false;
            }
        }
    }

