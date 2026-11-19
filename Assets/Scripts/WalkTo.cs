using System.Runtime.InteropServices;
using UnityEngine;

public class WalkTo : MonoBehaviour
{
    [SerializeField] private Transform walkToPoint;
    [SerializeField] private CharacterController player;

    private void Update()
    {
        player.SimpleMove(walkToPoint.position - player.transform.position);
        if (player.transform.position == walkToPoint.position)
        {
            
        }
    }
}
