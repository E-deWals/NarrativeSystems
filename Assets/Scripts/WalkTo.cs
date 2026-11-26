using System.Runtime.InteropServices;
using UnityEditor.Build.Content;
using UnityEngine;

public class WalkTo : MonoBehaviour
{
    [SerializeField] private Transform walkToPoint;
    [SerializeField] private float AcceptenceRadius;
    [SerializeField] private CharacterController player;

    [SerializeField] private GameObject[] gameObjectsToActivate;

    private void Update()
    {
        if ((walkToPoint.position - player.transform.position).magnitude <= AcceptenceRadius)
        {
            foreach (GameObject GO in gameObjectsToActivate)
            {
                GO.SetActive(true);
            }
            this.gameObject.SetActive(false);
        }
        else
        {
            //Debug.Log("is moving");
            player.Move(walkToPoint.position - player.transform.position);
        }

            //Debug.Log((player.transform.position - walkToPoint.position).magnitude);


    }
}
