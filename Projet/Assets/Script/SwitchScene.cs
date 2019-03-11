using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BestMasterYi
{
    public class SwitchScene : MonoBehaviour
    {
        public string Scene;
        public string Perso;

        private int n;
        
        public void Sceneload()
        {
            if (Scene == "MainMenu")
                SceneManager.LoadScene(Scene);
            
            else if (SceneManager.GetActiveScene().name == "CharacterSelect")
            {
                n = 0;
                foreach (var c in PersistantManagerScript.Instance.summoned)
                {
                    if (c == Perso)
                        n += 1;
                }

                if (n >= 1)
                {
                    PersistantManagerScript.Instance.perso = Perso;
                    SceneManager.LoadScene(Scene);
                }
            }
            else if (SceneManager.GetActiveScene().name == "DungeonSelect")
            {
                SceneManager.LoadScene(3);
                PersistantManagerScript.Instance.level = Scene;
            }
            else
                SceneManager.LoadScene(Scene);
        }
    }
}
