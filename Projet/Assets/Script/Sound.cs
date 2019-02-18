using UnityEngine;
using System.Collections;

namespace BestMasterYi
{



    public class Sound : MonoBehaviour
    {

        /// <summary>
        /// Singleton
        /// </summary>
        public static Sound Instance;


        public AudioClip playerShotSound;
        public AudioClip Death;
        public AudioClip CreepDeath;
        public AudioClip Warcry;

        void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("Multiple instances of SoundEffectsHelper!");
            }

            Instance = this;
        }


        public void MakePlayerShotSound()
        {
            MakeSound(playerShotSound);
        }

        public void DeathSound()
        {
            MakeSound(Death);
        }

        public void MakePlayerWarcry()
        {
            MakeSound(Warcry);
        }

        public void MakeCreepDeath()
        {
            MakeSound(CreepDeath);
        }


        /// <summary>
        /// Lance la lecture d'un son
        /// </summary>
        /// <param name="originalClip"></param>
        private void MakeSound(AudioClip originalClip)
        {
            AudioSource.PlayClipAtPoint(originalClip, transform.position);
        }
    }
}