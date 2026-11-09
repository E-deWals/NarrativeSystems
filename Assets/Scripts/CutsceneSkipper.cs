using UnityEngine;
using UnityEngine.Playables;

public class CutsceneSkipper : MonoBehaviour
{
    PlayableDirector timeline;

    private void Awake()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    public void SkipScene()
    {
        timeline.time = timeline.duration;
    }
}
