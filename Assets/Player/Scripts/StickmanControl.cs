using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StickmanControl : MonoBehaviour
{
    [SerializeField]private float SpeedWalk = 5.0f;
    [SerializeField]private float SpeedRun = 10.0f;
    [SerializeField]private float JumpForce = 40.0f;
    [SerializeField]private ParticleSystem DoubleJumpEffect;
    [SerializeField]private ParticleSystem DoubleJumpEffectCircle;

    public Rigidbody2D chest;

    public Slider SlowMotionSlider;
    public GameObject SlowMotionBar;

    public AudioSource slowaudio;

    public bool Ground;
    private bool DoubleJump, Slowmotion = false;
    private float slowtime;
    
    void Start()
    {
        slowtime = 0.5f;
    }

    void Update()
    {
        Movement();

        Jump();

        SlowMotion();
    }

    private void Movement()
    {
        if (Slowmotion == false)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    chest.AddForce((chest.transform.right * SpeedWalk), ForceMode2D.Impulse);
                }
                else
                {
                    chest.AddForce((chest.transform.right * SpeedRun), ForceMode2D.Impulse);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    chest.AddForce((-chest.transform.right * SpeedWalk), ForceMode2D.Impulse);
                }
                else
                {
                    chest.AddForce((-chest.transform.right * SpeedRun), ForceMode2D.Impulse);
                }
            }
        }
        else if (Slowmotion == true)
        {
            if (Input.GetKey(KeyCode.D))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    chest.AddForce((chest.transform.right * SpeedWalk * 0.5f), ForceMode2D.Impulse);
                }
                else
                {
                    chest.AddForce((chest.transform.right * SpeedRun * 0.5f), ForceMode2D.Impulse);
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    chest.AddForce((-chest.transform.right * SpeedWalk * 0.5f), ForceMode2D.Impulse);
                }
                else
                {
                    chest.AddForce((-chest.transform.right * SpeedRun * 0.5f), ForceMode2D.Impulse);
                }
            }
        }
    }

    private void Jump()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Ground == true)
            {
                chest.AddForce(new Vector3(0f, JumpForce, 0f), ForceMode2D.Impulse);
                Ground = false;
                DoubleJump = true;
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.W))
                    if (DoubleJump == true) 
                    {
                        DoubleJumpEffect.Play();
                        DoubleJumpEffectCircle.Play();
                        chest.AddForce(new Vector3(0f, JumpForce * 1.5f, 0f), ForceMode2D.Impulse);
                        DoubleJump = false;
                    }
            }
        }
    }

    private void SlowMotion()
    {
        if (Input.GetKey(KeyCode.Mouse3))
        {
            SlowMotionBar.SetActive(true);
            SlowMotionSlider.value = 0.5f;
            if (slowtime == 0.5f)
            {
                Time.timeScale = 0.25f;
                Time.fixedDeltaTime = 0.02f * Time.timeScale;
                slowaudio.Play();
                Slowmotion = true;
            }
        }
        if (Slowmotion == true)
        {
            slowtime -= Time.deltaTime;
            SlowMotionSlider.value = slowtime;
        }

        if (slowtime < 0)
        {
            SlowMotionBar.SetActive(false);
            Time.timeScale = 1f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
            Slowmotion = false;
            slowtime = 0.5f;
        }
    }
}