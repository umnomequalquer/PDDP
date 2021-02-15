using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PDDP {

    public class LoadTask : MonoBehaviour {
        [Header ("Load Seetings")]
        public bool loadUser;
        public RectTransform view;
        public GameObject task;

        [Header ("Collection")]
        public MAccount account;
        public MCollection collection;

        private List<GameObject> list = new List<GameObject> ();

        public void Load ()
        {
            Unload();
            foreach (Task _task in collection.taskDB.tasks)
            {
                if(account.loggedUser.tasks.Count >= 1)
                {
                    foreach (Task _task2 in account.loggedUser.tasks)
                    {
                        if (_task.uuid != _task2.uuid)
                        {
                            GameObject newTask = Instantiate(task);
                            newTask.transform.SetParent(view);
                            newTask.transform.GetComponent<TaskMono>().task = _task;
                            newTask.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = _task.name;
                            newTask.transform.Find("Desc").GetComponent<TextMeshProUGUI>().text = _task.desc;
                            list.Add(newTask);
                        }
                        else
                        {
                            GameObject newTask = Instantiate(task);
                            newTask.transform.SetParent(view);
                            newTask.transform.GetComponent<TaskMono>().task = _task;
                            newTask.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = _task.name;
                            newTask.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = _task.desc;
                            list.Add(newTask);
                        }
                    }
                }
                else
                {
                    GameObject newTask = Instantiate(task);
                    newTask.transform.SetParent(view);
                    newTask.transform.GetComponent<TaskMono>().task = _task;
                    newTask.transform.Find("Title").GetComponent<TextMeshProUGUI>().text = _task.name;
                    newTask.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = _task.desc;
                    list.Add(newTask);
                }
            }
        }

        public void Unload () {
            foreach (GameObject objects in list)
                Destroy (objects);

            list.Clear ();

        } // Unload

        public void OnEnable () {
            Load();
        }


    } // Class LoadTask

} // Namespace PDDP