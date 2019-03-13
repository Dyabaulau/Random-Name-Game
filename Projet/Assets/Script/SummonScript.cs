using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

namespace BestMasterYi
{
    public class SummonScript : MonoBehaviour
    {
        private int Money;
        
        public List<string> Mcharacter;
        public List<string> Rcharacter;
        public List<string> Ccharacter;

        private int n;
        public int M;
        public int R;

        public void Pull()
        {
            n = Random.Range(0, 101);
            if (n <= M)
                PersistantManagerScript.Instance.summoned.Add(Mcharacter[Random.Range(0, Mcharacter.Count)]);
            else if (n<=M+R)
                PersistantManagerScript.Instance.summoned.Add(Rcharacter[Random.Range(0, Rcharacter.Count)]);
            else
                PersistantManagerScript.Instance.summoned.Add(Ccharacter[Random.Range(0, Ccharacter.Count)]);
        }
    }
}
