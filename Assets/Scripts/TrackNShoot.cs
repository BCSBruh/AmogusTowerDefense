using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackNShoot : MonoBehaviour
{
    [Header("Transforms")]
    private Transform target;
    [SerializeField] private Transform partToRotate;
    [SerializeField] private Transform firePoint;

    [Header("Game Objects")]
    [SerializeField] private GameObject laser;

    [Header("Variables")]
    [SerializeField] private float range = 5f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float fireRate = 0.86f;
    [SerializeField] private float fireCountDown = 0f;

    private String enemyTag = "Amogus";

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void UpdateTarget()
    {
        //Find closest target
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        //Check if it is in range
        if (nearestEnemy != null && shortestDistance <= range)
            target = nearestEnemy.transform;
        else 
            target = null;
    }

    private void Update()
    {
        if (GameManager.gameIsOver)
        {
            gameObject.GetComponent<TrackNShoot>().enabled = false;
            gameObject.GetComponent<DragNDrop>().enabled = false;
        }

        if (target == null)
            return;

        //Rotate the turret
        Vector3 directionOfEnemy = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(directionOfEnemy);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0, rotation.y, 0);

        //Shoot the laser
        if (fireCountDown <= 0)
        {
            Shoot();
            fireCountDown = 1f / fireRate;
        }

        fireCountDown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject laserNew = (GameObject)Instantiate(laser, firePoint.position, firePoint.rotation);
        LaserShooter shooter = laserNew.GetComponent<LaserShooter>();

        if (shooter != null)
            shooter.Seek(target);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }
}
