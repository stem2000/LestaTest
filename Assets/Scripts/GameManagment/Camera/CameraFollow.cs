using Cinemachine;
using PlayerLogic;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CameraFollow : MonoBehaviour
{
    public void Initialize()
    {
        var camera = GetComponent<CinemachineVirtualCamera>();
        var player = FindObjectOfType<PlayerBus>();

        if(player != null)
            camera.Follow = player.GetComponentInChildren<CameraTarget>().transform;
    }
}
