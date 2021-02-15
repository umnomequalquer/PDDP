using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    public class TaskMono : MonoBehaviour {

        public MAccount account;

        public Task task;

        public GameObject check;

        public void Update () {
            if (task.status == Status.Complete)
                check.SetActive (true);

            if (task.status == Status.OnGoing)
                check.SetActive (false);
        }

        public void Change ()
        {
            check.SetActive(true);
            bool canAdd = true;
            
            if (account.loggedUser.tasks.Count >= 1)
            {
                foreach (Task _task in account.loggedUser.tasks)
                {
                    if (_task.uuid == task.uuid)
                    {
                        account.loggedUser.tasks.Remove(_task);
                        canAdd = false;
                        break;
                    }
                }
            }
            if (canAdd)
            {
                Debug.Log("CanAdd");
                task.status = Status.Complete;
                account.loggedUser.tasks.Add (task);
            }

        } // Change

        //public void AddTask () {
        //    bool canAdd = true;
        //    foreach (Task _task in account.loggedUser.tasks) {
        //        if (_task.uuid == task.uuid)
        //            canAdd = false;
        //    }

        //    if (canAdd) {
        //        task.status = Status.Complete;
        //        account.loggedUser.tasks.Add (task);
        //    }

        //} // AddTask

        //public void RemoveTask () {

        //    foreach (Task _task in account.loggedUser.tasks) {
        //        if (_task.uuid == task.uuid)
        //            account.loggedUser.tasks.Remove (_task);
        //    }

        //} // RemoveTask

    } // Class Task

} // Namespace PDDP