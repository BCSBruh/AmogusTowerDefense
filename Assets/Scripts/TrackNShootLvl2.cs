using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrackNShootLvl2 : MonoBehaviour
{
    [Header("Transforms")]
    private Transform target;
    [SerializeField] private Transform partToRotate;
    [SerializeField] private Transform firePoint1;
    [SerializeField] private Transform firePoint2;

    [Header("Game Objects")]
    [SerializeField] private GameObject laser;
    private AudioSource gunSound;

    [Header("Variables")]
    [SerializeField] private float range = 5f;
    [SerializeField] private float turnSpeed = 10f;
    [SerializeField] private float fireRate = 0.86f;
    [SerializeField] private float fireCountDown = 0f;

    private String enemyTag = "Amogus";

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        gunSound = GetComponent<AudioSource>();
    }

    private void UpdateTarget()
    {
        //Find closest target
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < shortestDistance)
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
            StartCoroutine(ShootNext());
            fireCountDown = 1f / fireRate;
            StopCoroutine(ShootNext());
        }

        fireCountDown -= Time.deltaTime;
    }

    private void Shoot1()
    {
        GameObject laserNew1 = (GameObject)Instantiate(laser, firePoint1.position, firePoint1.rotation);
        LaserShooter shooter1 = laserNew1.GetComponent<LaserShooter>();

        shooter1.Seek(target);

        gunSound.Play();
    }

    private void Shoot2()
    {
        GameObject laserNew2 = (GameObject)Instantiate(laser, firePoint2.position, firePoint2.rotation);
        LaserShooter shooter2 = laserNew2.GetComponent<LaserShooter>();

        shooter2.Seek(target);

        gunSound.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.red;
    }

    IEnumerator ShootNext()
    {
        Shoot1();
        yield return new WaitForSeconds(0.1f);
        Shoot2();
    }
}
