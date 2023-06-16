/*using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    //public string subtitleText;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
       TextMeshProUGUI text = playerData as TextMeshProUGUI;
       string currentText = "";
       float currentRcolor = 1;
       float currentGcolor = 1;
       float currentBcolor = 1;
       float currentAlpha =0f;
       
       if(!text) { return; }

       int inputCount = playable.GetInputCount();
       for(int i = 0; i < inputCount; i++) {
       float inputWeight = playable.GetInputWeight(i);
       if(inputWeight>0f)
       {
        ScriptPlayable<SubtitleBehavior> inputPlayable=(ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);
        SubtitleBehavior input = inputPlayable.GetBehaviour();
        currentText = input.subtitleText;
        currentRcolor = input.rcolor;
        currentGcolor = input.gcolor;
        currentBcolor = input.bcolor;
        currentAlpha=inputWeight;
       }
       }
       text.text = currentText;
       text.color=new Color(currentRcolor,currentGcolor,currentBcolor,currentAlpha);
    }
}*/

using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    private TextMeshProUGUI text;
    private string targetText;
    private float targetRcolor;
    private float targetGcolor;
    private float targetBcolor;
    private float targetAlpha;
    private float typingSpeed = 20f; // Adjust typing speed as desired
    private float elapsedTypingTime = 0f;
    private int visibleCharacterCount = 0;
    private string printedText= "";
    

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        text = playerData as TextMeshProUGUI;
        if (!text)
            return;


        int inputCount = playable.GetInputCount();
        for (int i = 0; i < inputCount; i++)
        {
            float inputWeight = playable.GetInputWeight(i);
            if (inputWeight > 0f)
            {
                ScriptPlayable<SubtitleBehavior> inputPlayable = (ScriptPlayable<SubtitleBehavior>)playable.GetInput(i);
                SubtitleBehavior input = inputPlayable.GetBehaviour();
                targetText = input.subtitleText;
                targetRcolor = input.rcolor;
                targetGcolor = input.gcolor;
                targetBcolor = input.bcolor;
                targetAlpha = inputWeight;
            }
        }
        //visibleCharacterCount=0;
        if (targetText != text.text && targetText!=printedText)
        {
            elapsedTypingTime += (float)info.deltaTime;
            if (elapsedTypingTime >= 1f / typingSpeed)
                {
                    visibleCharacterCount++;
                    elapsedTypingTime = 0f;
                    printedText = targetText.Substring(0, visibleCharacterCount);
                }

            if (visibleCharacterCount >= targetText.Length)
                {
                    visibleCharacterCount = targetText.Length;
                    visibleCharacterCount=0;
                }

        }

        text.text = targetText.Substring(0, visibleCharacterCount);
        text.color = new Color(targetRcolor, targetGcolor, targetBcolor, targetAlpha);
    }
}