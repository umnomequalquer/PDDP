using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PDDP {

    [CreateAssetMenu (menuName = MenuUtil.TASK_COLLECTION)]
    public class TCollection : Scriptable {

        public List<Task> tasks = new List<Task> ();

    } // Class TCollection

} // Namespace PDDP