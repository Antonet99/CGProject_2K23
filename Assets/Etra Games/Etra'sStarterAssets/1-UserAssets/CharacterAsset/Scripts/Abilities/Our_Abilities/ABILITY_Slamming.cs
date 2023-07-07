using UnityEngine;
using Etra.StarterAssets.Abilities;
using Etra.StarterAssets.Input;
using Etra.StarterAssets;
using Etra.StarterAssets.Source;

public class ABILITY_Slamming : EtraAbilityBaseClass
    {
    private Animator _animator,_enemyAnimator;
    private Transform parentTransform;
    private StarterAssetsInputs _input;
    bool _hasAnimator, _areNear;
    public GameObject enemy;
        

    public override void abilityStart()
        {
            mainController = GetComponentInParent<EtraCharacterMainController>();
            _input = GetComponentInParent<StarterAssetsInputs>();
            _hasAnimator = EtrasResourceGrabbingFunctions.TryGetComponentInChildren<Animator>(EtraCharacterMainController.Instance.modelParent);
            if (_hasAnimator) {
                _animator = EtraCharacterMainController.Instance.modelParent.GetComponentInChildren<Animator>();
            }
            _enemyAnimator = enemy.GetComponentInChildren<Animator>();
        }

        public override void abilityUpdate()
        {
            if (!enabled){
                _input.slam = false;
                return;
            }
            if (_hasAnimator && _input.slam==true){
                parentTransform=transform.parent;
                _areNear=Vector3.Distance(parentTransform.position,enemy.transform.position)<=2f?true:false;
                Debug.Log(Vector3.Distance(parentTransform.position,enemy.transform.position));
                Debug.Log(_areNear);
                if(_areNear){
                    Debug.Log("presa");
                    _animator.SetTrigger("Slamming");
                    _enemyAnimator.SetTrigger("Slammed");
                }
                _input.slam=false;
            }
        }
    }
