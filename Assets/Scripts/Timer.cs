using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Timer : MonoBehaviour
{
    public float timeValue = 180;
    public Text timeText;
    //private HealthStatusManager _healthStatusManager;
    private AdjustAnimation _ending;

    //void Start()
    //{
        //_healthStatusManager=GameObject.Find("EtraCharacterAssetBase").GetComponent<HealthStatusManager>();
    //}
    
    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }
        
        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0)
        {
            timeToDisplay = 0; 
            _ending.ChangeScene();
            /*if (_healthStatusManager.playerLife >= _healthStatusManager.enemyLife)
            {
                _ending.Win();

            }
            else if (_healthStatusManager.playerLife < _healthStatusManager.enemyLife)
            {
                _ending.Die();
            }*/
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
