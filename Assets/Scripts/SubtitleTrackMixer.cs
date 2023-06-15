using TMPro;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleTrackMixer : PlayableBehaviour
{
    public string subtitleText;

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
       text.color=new Color(currentRcolor,currentGcolor,currentBcolor,info.weight);
    }
}
