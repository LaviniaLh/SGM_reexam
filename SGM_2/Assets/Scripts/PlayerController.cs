using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D player;

    [SerializeField]
    private float speed;

    [SerializeField]
    private string upDownName;
    [SerializeField]
    private string leftRightName;
    private float updown;
    private float shoot;
    private float leftright;
    [SerializeField]
    private string shootName;


    private int CurrentPower;
    private int CurrentHealth;
    [SerializeField]
    private string healthLife;
    [SerializeField]
    private string bulletPower;


    [SerializeField]
    private GameObject playerDies;
 
    [SerializeField]
    private Transform locationForBullet;
 
    private bool bulletNrController;

    [SerializeField]
    private AudioSource fire;
    [SerializeField]
	private AudioSource backgroundMusic;
	[SerializeField]
	private AudioSource gameOverMusic;

    [SerializeField]
    private GameObject flameUp;
    [SerializeField]
  
    private GameObject flameDown;
    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        CurrentHealth = 100;
        initializeValues(healthLife);
        initializeValues(bulletPower);
        CurrentPower = 100;    
        bulletNrController = true;
    }

    void initializeValues(string slider)
    {
        Slider s = GameObject.FindGameObjectWithTag(slider).GetComponent<Slider>();
        s.minValue = 0;
        s.maxValue = 100;
        s.wholeNumbers = true;
        s.value = 100;
    }
    public void changeValues(string slider, int newvalue)
    {
        Slider s = GameObject.FindGameObjectWithTag(slider).GetComponent<Slider>();
        s.value = newvalue;
    }

    // Update is called once per frame
    void Update()
    {
        //movements
        updown = Input.GetAxis(upDownName);
        leftright = Input.GetAxis(leftRightName);
        shoot = Input.GetAxis(shootName);

        flameUp.SetActive(true);
        flameDown.SetActive(true);


        if (updown != 0f)
        {
            player.transform.Translate(Vector3.up * Time.deltaTime * updown * speed);

                if (updown > 0)
                {
                    flameUp.SetActive(false);
                    flameDown.SetActive(true);
                }
                else
                {
                    flameUp.SetActive(true);
                    flameDown.SetActive(false);
                }
        }

        if (leftright != 0f)
        {
            player.transform.Translate(Vector3.right * Time.deltaTime * leftright * speed);

            if (leftright > 0)
            {
                flameUp.SetActive(false);
                flameDown.SetActive(true);
            }
            else
            {
                flameUp.SetActive(true);
                flameDown.SetActive(false);
            }
        }

        //shoot
        if (shoot != 0f && CurrentPower > 0 && bulletNrController == true)
        {   
            fire.Play();
            
            if (player.tag == "PlayerOne")
            {
                GameObject bullet = ObjPoolerOne.objPooler1.GetPooledBullet(); 
            
                if (bullet != null) 
                {
                    bullet.transform.position = locationForBullet.position;
                    bullet.transform.rotation = locationForBullet.rotation;
                    bullet.SetActive(true);
                }
            }

            if (player.tag == "PlayerTwo")
            {
                GameObject bullet = ObjPoolerTwo.objPooler2.GetPooledBullet(); 
            
                if (bullet != null) 
                {
                    bullet.transform.position = locationForBullet.position;
                    bullet.transform.rotation = locationForBullet.rotation;
                    bullet.SetActive(true);
                }
            }
            

            bulletNrController = false;
            CurrentPower -= 1;
            changeValues(bulletPower, CurrentPower); 
        }
        else
        {
            bulletNrController = true;
        }

        if (CurrentHealth<=0)
        {
            playerDies.SetActive(true);
            if(backgroundMusic.isPlaying)
			{
				backgroundMusic.Stop();
				gameOverMusic.Play();
			}
        }

        if(CurrentPower <= 0)
        {
            StartCoroutine(fillPower());
        }
    }
 
    public void PlayerIsHurt(int amount)
    {
        CurrentHealth -= amount;

        changeValues(healthLife, CurrentHealth);     
    }

    IEnumerator fillPower()
    {
        yield return new WaitForSeconds(10f);
        changeValues(bulletPower, 100);
        CurrentPower = 100;
    }
    
}
