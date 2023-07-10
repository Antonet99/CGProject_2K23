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
    private Vector3 currentRotation, currentEnemyRotation;
    private Quaternion newRotation, newEnemyRotation;

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
                    currentRotation = parentTransform.rotation.eulerAngles;
                    newRotation=Quaternion.Euler(currentRotation.x,currentRotation.y,0);
                    currentEnemyRotation = enemy.transform.rotation.eulerAngles;
                    newEnemyRotation=Quaternion.Euler(currentEnemyRotation.x,currentEnemyRotation.y,90);
                    parentTransform.rotation=newRotation;
                    enemy.transform.rotation = newEnemyRotation;
                    _animator.SetTrigger("Press");
                    _enemyAnimator.SetTrigger("Throw");
                }
                _input.throwenemy=false;
            }
        }
    }


