using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SubtitleClip : PlayableAsset
{
    public string subtitleText;
    public float rcolor;
    public float gcolor;
    public float bcolor;

    public override Playable CreatePlayable(PlayableGraph graph,GameObject owner) {
        var playable = ScriptPlayable<SubtitleBehavior>.Create(graph);
        SubtitleBehavior subtitleBehavior = playable.GetBehaviour();
        subtitleBehavior.subtitleText=subtitleText;
        subtitleBehavior.rcolor=rcolor; 
        subtitleBehavior.gcolor=gcolor;
        subtitleBehavior.bcolor=bcolor;
        return playable;
    }
}
