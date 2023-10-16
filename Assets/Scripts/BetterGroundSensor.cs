using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterGroundSensor : MonoBehaviour
{
    public List<GroundSensorLimbs> childLimbSensors = new List<GroundSensorLimbs>();

    public Rigidbody2D rightLegBody;
    public Rigidbody2D leftLegBody;

    public bool currentlyGrounded = false;
    public bool readyToJump = false;

    float legPower = 40f;

    float landingCooldownTime = 0.3f;
    float landingCooldownTimer;

    bool headBonked = false;
    bool bonkSoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        landingCooldownTimer = landingCooldownTime;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform childWeAreGetting = transform.GetChild(i);

            GroundSensorLimbs limbSensorWeAreGetting = childWeAreGetting.gameObject.AddComponent<GroundSensorLimbs>();

            childLimbSensors.Add(limbSensorWeAreGetting);

            if (childWeAreGetting.name == "RightLeg") {
                rightLegBody = childWeAreGetting.GetComponent<Rigidbody2D>();

            }
            else if (childWeAreGetting.name == "LeftLeg")
            {
                leftLegBody = childWeAreGetting.GetComponent<Rigidbody2D>();
            }




        }



    }

    // Update is called once per frame
    void Update()
    {
        bool foundGroundLimb = false;

        for (int i = 0; i < childLimbSensors.Count; i++)
        {
            GroundSensorLimbs sensorWeAreChecking = childLimbSensors[i];

            if (sensorWeAreChecking.grounded == true)
            {
                foundGroundLimb = true;

                if (sensorWeAreChecking.gameObject.name == "Head")
                {
                    headBonked = true;
                }
            }

        }

        
        

        if (foundGroundLimb == true)
        {

            currentlyGrounded = true;

                
        }
        else
        {
            currentlyGrounded = false;
        }

        

        

        if (currentlyGrounded)
        {
            if (headBonked && !bonkSoundPlayed)
            {
                bonkSoundPlayed = true;

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[4]);
            }

            if (landingCooldownTimer > 0)
            {
                landingCooldownTimer -= Time.deltaTime;
                readyToJump = false;
            }
            else
            {
                if (readyToJump == false) {
                    readyToJump = true;

                    SoundManager.source.PlayOneShot(SoundManager.soundEffects[1]);
                }
                
            }

            if (Input.GetKeyDown(KeyCode.P) && readyToJump)
            {
                leftLegBody.AddForce(new Vector3(2, 3, 0) * legPower, ForceMode2D.Impulse);

                currentlyGrounded = false;

                readyToJump = false;

                landingCooldownTimer = landingCooldownTime;

                //SoundManager.source.clip = SoundManager.soundEffects[0];

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[0]);

                headBonked = false;
                bonkSoundPlayed = false;
            }
            else if (Input.GetKeyDown(KeyCode.O) && readyToJump)
            {
                rightLegBody.AddForce(new Vector3(-2, 3, 0) * legPower, ForceMode2D.Impulse);

                currentlyGrounded = false;

                readyToJump = false;

                landingCooldownTimer = landingCooldownTime;

                SoundManager.source.PlayOneShot(SoundManager.soundEffects[0]);
                
                headBonked = false;
                bonkSoundPlayed = false;

            }


        }

        
    }
}
