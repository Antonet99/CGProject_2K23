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
                _input.throwenemy = false;
                return;
            }
            if (_hasAnimator && _input.throwenemy==true){
                parentTransform=transform.parent;
                _areNear=Vector3.Distance(parentTransform.position,enemy.transform.position)<=2f?true:false;
                
                Debug.Log(Vector3.Distance(parentTransform.position,enemy.transform.position));
                Debug.Log(_areNear);
                if(_areNear){
                    Debug.Log("presa");
                    //parentTransform.Rotate(0,-81.329f,0);
                    //enemy.transform.Rotate(0,-89.445f,0);
                    _animator.SetTrigger("Press");
                    _enemyAnimator.SetTrigger("Throw");
                }
                _input.throwenemy=false;
            }
        }
    }


