using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    public class LoadAchievements : MonoBehaviour {
        [Header("Load Seetings")]
        public bool loadUser;
        public RectTransform view;
        public GameObject achievement;

        [Header ("Collection")]
        public MAccount account;
        public MCollection collection;

        private List<GameObject> list = new List<GameObject>();

        public void Load() {
            foreach (Achievement achievements in collection.achievementDB.achievements)
            {
                if (account.loggedUser.achievements.Count >= 1)
                {
                    
                    foreach (Achievement achiev in account.loggedUser.achievements)
                    {
                        if (achievements.uuid != achiev.uuid)
                        {
                            GameObject newAchiev = Instantiate(achievement);
                            newAchiev.transform.SetParent(view);
                            newAchiev.transform.GetComponent<ProgressBar>().current = achievements.progress;
                            newAchiev.transform.Find("Icon").GetComponent<SVGImage>().sprite = achievements.icon;
                            list.Add(newAchiev);
                        }
                        else
                        {
                            GameObject newAchiev = Instantiate(achievement);
                            newAchiev.transform.SetParent(view);
                            newAchiev.transform.GetComponent<ProgressBar>().current = achiev.progress;
                            newAchiev.transform.Find("Icon").GetComponent<SVGImage>().sprite = achiev.icon;
                            list.Add(newAchiev);
                        }
                    }
                } else
                {
                    GameObject newAchiev = Instantiate(achievement);
                    newAchiev.transform.SetParent(view);
                    newAchiev.transform.GetComponent<ProgressBar>().current = achievements.progress;
                    newAchiev.transform.Find("Icon").GetComponent<SVGImage>().sprite = achievements.icon;
                    list.Add(newAchiev);
                }
            }
         }

        public void Unload () {
            foreach (GameObject objects in list) 
                Destroy (objects);

            list.Clear ();

        } // Unload

        public void OnEnable () {
            Load ();
        }

        public void OnDisable () {
            Unload ();
        }

    } // Class LoadAchievements

} // Namespace PDDP