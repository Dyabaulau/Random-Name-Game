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
        
        public void Sceneload()
        {
            if (SceneManager.GetActiveScene().name == "CharacterSelect")
            {
                PersistantManagerScript.Instance.perso = Perso;
                SceneManager.LoadScene(Scene);
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
