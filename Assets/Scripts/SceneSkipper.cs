using UnityEngine;
using UnityEngine.Playables;

public class SceneSkipper : MonoBehaviour
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
