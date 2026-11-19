using UnityEngine;
using UnityEngine.Playables;

public class MixingGame : MonoBehaviour
{
    [SerializeField] private float angleToUse = 45;
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private float stopAnimationAfter = 0.25f;

    Vector2 centerPoint;

    Vector2 currentMousePosition;
    Vector2 previousMousePosition;
    Vector2 previousPreviousMousePosition;

    private float cooldown = 0.1f;


    public void CheckIfCircle(Vector2 mousePosition)
    {
        currentMousePosition = mousePosition;

        Vector2 side1 = currentMousePosition - centerPoint;
        Vector2 side2 = previousMousePosition - centerPoint;
        Vector2 side3 = previousPreviousMousePosition - centerPoint;

        float angle = Vector2.Angle(side1, side2);
        float angle2 = Vector2.Angle(side2, side3);

        if (angle + angle2 > angleToUse)
        {
            timeline.Play();
            cooldown = Time.time + stopAnimationAfter;
        }
        else if (Time.time > cooldown)
        {
            timeline.Pause();
        }

        previousMousePosition = currentMousePosition;
        previousPreviousMousePosition = previousMousePosition;
    }
}
