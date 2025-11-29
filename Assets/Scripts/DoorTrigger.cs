using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public struct DoorChildTag : IComponentData {}

namespace DefaultNamespace
{
    public class DoorTrigger : MonoBehaviour, IInteractable
    {
        public string InteractionMessage { get; } = "Press 'E' to open the door";

        public void Interact()
        {
            // Logic to open the door
            Debug.Log("The door has been opened!");
            // Disable all children
            foreach (Transform child in transform)
            {
                // child.gameObject.SetActive(false);
                child.transform.position = new Vector3(
                    child.transform.position.x,
                    2f,
                    child.transform.position.z);
            }
        }
    }
}