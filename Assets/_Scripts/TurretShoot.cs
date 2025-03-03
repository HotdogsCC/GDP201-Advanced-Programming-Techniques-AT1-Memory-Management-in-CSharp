using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] private GameObject shell;

    [SerializeField] private GameObject firePoint;

    [SerializeField] private List<GameObject> shellsFired = new List<GameObject>();

    [SerializeField] private float rapid_fire_time = 0.25f;
    private float rapid_fire_timer = 0;
    private float angle = 7.0f;

    private float destroyShellsTime = 5;
    private float destroyShellTimer = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && rapid_fire_timer > rapid_fire_time)
        {
            shellsFired.Add(Instantiate(shell, firePoint.transform.position, firePoint.transform.rotation));
            rapid_fire_timer = 0;
        }

        //Rapid fire on RMB
        if (Input.GetButton("Fire2") && rapid_fire_timer > rapid_fire_time/3.0)
        {
            // Generate a random axis
            Vector3 randomAxis = UnityEngine.Random.onUnitSphere;

            // Generate a small random angle
            float randomAngle = UnityEngine.Random.Range(-angle, angle);

            // Create a small rotation around the random axis
            Quaternion randomRotation = Quaternion.AngleAxis(randomAngle, randomAxis);

            // Combine the original quaternion with the random rotation
            var rotation = firePoint.transform.rotation * randomRotation;

            shellsFired.Add(Instantiate(shell, firePoint.transform.position, rotation));
            rapid_fire_timer = 0;
        }

        rapid_fire_timer += Time.deltaTime;
        destroyShellTimer += Time.deltaTime;
        if (destroyShellTimer >= destroyShellsTime)
        {
            destroyShellTimer -= destroyShellsTime;
            DestroyShells();
        }
}


    public int GetNumberOfShellsFired()
    {
        return shellsFired.Count;
    }

    public void DestroyShells()
    {
        //Track the shells and if ShouldBeDestroyed, destroy the shell. 
        for (int i = 0; i < shellsFired.Count; i++)
        {
            if(shellsFired[i] != null)
                if(shellsFired[i].GetComponent<ProjectileHandler>().ShouldBeDestroyed())
                    Destroy(shellsFired[i]);
        }
    }
    
}
