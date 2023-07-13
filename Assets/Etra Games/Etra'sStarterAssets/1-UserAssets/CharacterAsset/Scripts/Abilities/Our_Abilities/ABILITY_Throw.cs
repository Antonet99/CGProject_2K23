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
                    enemy.transform.position= new Vector3(enemy.transform.position.x-0.87684f,enemy.transform.position.y-0.13948f,enemy.transform.position.z);
                    _animator.SetTrigger("Press");
                    foreach (AnimatorControllerParameter param in _enemyAnimator.parameters)
                    {
                        if (param.type == AnimatorControllerParameterType.Bool)
                        {
                            _enemyAnimator.SetBool(param.name, false);
                        }
                    }
                    _enemyAnimator.SetTrigger("Throw");
                    _healthStatusManager.takeDamage(6,"enemy","throw");
                    _healthStatusManager.ResizeBar(_healthStatusManager.enemyLife,_healthStatusManager.enemyBarTransform);
                }
                _input.throwenemy=false;
            }
        }
    }


