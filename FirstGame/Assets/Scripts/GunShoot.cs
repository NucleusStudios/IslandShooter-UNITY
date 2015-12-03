using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;

[RequireComponent(typeof(GameObject))]
public class GunShoot : MonoBehaviour {
    

    //Errors I need to fix: ************ "The Error" ****************
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15F;
    public float range = 10000F;
    public float gunSwitchTime = 0.0005F;
    
    float timer;
    float effectsDisplayTime = 0.2f;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    
   
    void Awake()
    {
        //returns the number of the shootable layer
        //shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
       
    }


    void Update()
    {
        timer += Time.deltaTime;
       

        GameObject akIden = GameObject.FindGameObjectWithTag("AK47");
        GameObject umpIden = GameObject.FindGameObjectWithTag("UMP");

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            DisableEffects();
        }
        
        
    }

    public void DisableEffects()
    {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;
        gunAudio.Play();
        gunLight.enabled = true;
        gunParticles.Stop();
        gunParticles.Play();
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);
        shootRay.origin = transform.position;
        shootRay.direction = -transform.up;
        ////out shoot hit tells you that you hit something
        //if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        //{
        //    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();
        //    if (enemyHealth != null)
        //    {
        //        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
        //    }
        //    gunLine.SetPosition(1, shootHit.point);
        //}
        //just draws out a line between 1 and 100 in the direction
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
    }
}
