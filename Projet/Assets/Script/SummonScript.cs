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

        public List<string> character;
        private HashSet<string> summoned;
        
        
        public HashSet<string> Summoned
        {
            get => summoned;
            set => summoned = value;
        }

        private int n = 0;
        public int M;
        public int R;

        public void Pull()
        {
            n = Random.Range(0, 100);
            if (n <= M)
                unlock(Mcharacter[Random.Range(0, Mcharacter.Count - 1)]);
            else if (n<=M+R)
                unlock(Rcharacter[Random.Range(0, Rcharacter.Count - 1)]);
            else
                unlock(Ccharacter[Random.Range(0, Ccharacter.Count - 1)]);
        }

        public void unlock(string name)
        {
            foreach (var c in summoned)
            {
                if (c == name)
                {
                    return;
                }
            }
            Summoned.Add(name);  
        }
    }
}
