using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BestMasterYi
{
    public class PersistantManagerScript : MonoBehaviour
    {
        public static PersistantManagerScript Instance { get; private set; }

        public List<string> summoned;
        public int money;
        public string perso;
        public string level;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}