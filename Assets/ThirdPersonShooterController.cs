using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;

    private StarterAssetsInputs starterAssetsInput;
    private void Awake()
    {
        starterAssetsInput = GetComponent<StarterAssetsInputs>();
    }
    // Update is called once per frame
    void Update()
    {
        if(starterAssetsInput.aim)
        {
            aimVirtualCamera.gameObject.SetActive(true);
        }
        else
        {
            aimVirtualCamera.gameObject.SetActive(false);
        }
    }
}
