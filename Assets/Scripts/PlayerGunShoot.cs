using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class PlayerGunShoot : MonoBehaviour
{

    public float fireRate = 0.25f;                                      // Number in seconds which controls how often the player can fire
    public float weaponRange = 20f;                                     // Distance in Unity units over which the player can fire

    public Transform gunEnd;
    public ParticleSystem muzzleFlash;
    public ParticleSystem cartridgeEjection;

    public GameObject metalHitEffect;
    public GameObject stoneHitEffect;

    private float nextFire;                                             // Float to store the time the player will be allowed to fire again, after firing
    private Animator anim;
    private GunAim gunAim;

    void Start()
    {
        anim = GetComponent<Animator>();
        gunAim = GetComponentInParent<GunAim>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire 
            //&& !gunAim.GetIsOutOfBounds()
            )
        {
            nextFire = Time.time + fireRate;
            //muzzleFlash.Play();
            //cartridgeEjection.Play();
            //anim.SetTrigger("Fire");

            Vector3 rayOrigin = gunEnd.position;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, gunEnd.forward, out hit, weaponRange))
            {
                HandleHit(hit);
            }
        }
    }

    void HandleHit(RaycastHit hit)
    {
        if (hit.collider.sharedMaterial != null)
        {
            string materialName = hit.collider.sharedMaterial.name;

            print(materialName);

            switch (materialName)
            {
                case "Metal":
                    SpawnDecal(hit, metalHitEffect);
                    break;
                case "Stone":
                    SpawnDecal(hit, stoneHitEffect);
                    break;
            }
        }
    }

    void SpawnDecal(RaycastHit hit, GameObject prefab)
    {
        GameObject spawnedDecal = GameObject.Instantiate(prefab, hit.point, Quaternion.LookRotation(hit.normal));
        spawnedDecal.transform.SetParent(hit.collider.transform);
    }
}