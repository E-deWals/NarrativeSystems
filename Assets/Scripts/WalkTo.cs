using System.Runtime.InteropServices;
using UnityEngine;

public class WalkTo : MonoBehaviour
{
    [SerializeField] private Transform walkToPoint;
    [SerializeField] private CharacterController player;

    public void WalkTowards()
    {
        player.SimpleMove(walkToPoint.position - player.transform.position);
    }
}
