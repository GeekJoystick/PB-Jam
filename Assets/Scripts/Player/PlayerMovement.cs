using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public int maxAmmo;
    public float speed = 18f;
    public float gravity = -20f;
    public float jumpHeight = 2f;
    public float jumpBufferDelay = 0.2f;
    public float groundDistance = 0.2f;
    public float ammoReloadDelay = 5f;
    public Transform groundCheck;
    public Transform shootPos;
    public GameObject potato;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;
    float currSpeed;
    float currJumpHeight;
    float jumpBuffer = 0f;
    [HideInInspector]
    public int ammo;
    float ammoReload;

	//Sound
	public AudioSource ShootTagSound;
	public AudioSource AmmoCollectSound;


	// Start is called before the first frame update
	void Start()
    {
        ammo = maxAmmo;
        ammoReload = 1f;
        currSpeed = speed;
        currJumpHeight = jumpHeight;
		ShootTagSound = GameObject.Find("ShootTagSound").GetComponent<AudioSource>();
		AmmoCollectSound = GameObject.Find("AmmoCollectSound").GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0){
            velocity.y = -10f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right*x+transform.forward*z;
        controller.Move(move*currSpeed*Time.deltaTime);

        if (jumpBuffer > 0f){
            jumpBuffer -= Time.deltaTime;
        }
        if (Input.GetKeyDown("space")){
            jumpBuffer = jumpBufferDelay;
        }

        if (jumpBuffer > 0f && isGrounded){
            velocity.y = currJumpHeight;
        }

        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity*Time.deltaTime);
        
        ammoReload -= Time.deltaTime;
        if (ammoReload <= 0f && ammo > 0){
            if (Input.GetButtonDown("Fire1")){
                GameObject currPotato = Instantiate(potato, shootPos.position, GetComponent<MouseLook>().camera.transform.rotation);
                currPotato.GetComponent<Rigidbody>().AddForce(currPotato.transform.forward*1000f);
                currPotato.tag = "Player";
                ammoReload = ammoReloadDelay;
                ammo--;
				if (!ShootTagSound.isPlaying)
				{
					ShootTagSound.Play();
				}
			}
        }

        Collider[] hitColliders = Physics.OverlapSphere(groundCheck.position, .5f);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.tag == "Ammo"){
                if (ammo < maxAmmo){
                    Destroy(hitCollider.gameObject);
                    ammo = maxAmmo;
					if (!AmmoCollectSound.isPlaying)
					{
						AmmoCollectSound.Play();
					}
				}
            }
        }
    }
}
