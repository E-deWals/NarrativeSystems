using UnityEngine;
using UnityEngine.Playables;

public class MixingGame : MonoBehaviour
{
    [SerializeField] private float angleToUse = 45;
    [SerializeField] private PlayableDirector timeline;
    [SerializeField] private float stopAnimationAfter = 0.25f;
    [SerializeField] private float maxDistance = 10;


    Vector2 centerPoint = new Vector2(Screen.width / 2, Screen.height / 2);
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
        float distance = (currentMousePosition - centerPoint).magnitude;
        if (angle + angle2 > angleToUse && distance <= maxDistance)
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
