using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SmartHome.Devices.Virtual
{
    public class RadioBehavior : SmartDevice
    {

        [SerializeField]
        private bool on;
        private int trackNum;
        // Use this for initialization
        void Start()
        {
            Debug.Log("Playing Green Hill Zone...");
            trackNum = 1;
            on = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown("r"))
                ToggleOnOff();
            if (Input.GetKeyDown("n"))
                PlayNext();
            if (on)
            {
                this.gameObject.GetComponent<AudioSource>().mute = false;
            }
            else
            {
                this.gameObject.GetComponent<AudioSource>().mute = true;
            }
        }

        public void ToggleOnOff()
        {
            if (on)
                on = false;
            else
            {
                on = true;
                this.gameObject.GetComponent<AudioSource>().Play();
            }

        }

        public void SetSong(int songNum)
        {
            trackNum = songNum;
            switch (songNum)
            {
                case 1:
                    Debug.Log("Playing Green Hill Zone...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("GreenHillZone") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 2:
                    Debug.Log("Playing Seaside Hill...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("SeasideHill") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 3:
                    Debug.Log("Playing City Escape...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("CityEscape") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 4:
                    Debug.Log("Playing Rooftop Run...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("RooftopRun") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 5:
                    Debug.Log("Shrek is love...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("allStar") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 6:
                    Debug.Log("To me, flirting is just like a sport...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("mambo5") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 7:
                    Debug.Log("Oh no...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("meme") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                case 8:
                    Debug.Log("Playing Backstreet Boys...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("everybody") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
                default:
                    Debug.Log("Playing Default...");
                    this.gameObject.GetComponent<AudioSource>().clip = Resources.Load("ShootingStars") as AudioClip;
                    if (on)
                        this.gameObject.GetComponent<AudioSource>().Play();
                    break;
            }
        }

        public void PlayRandomSong()
        {
            UnityEngine.Random rand = new UnityEngine.Random();
            int randomNumber = UnityEngine.Random.Range(1, 9);
            SetSong(randomNumber);
        }

        public void PlayNext()
        {
            SetSong(trackNum + 1);
        }

        public void PlayPrev()
        {
            SetSong(trackNum - 1);
        }
    }
}