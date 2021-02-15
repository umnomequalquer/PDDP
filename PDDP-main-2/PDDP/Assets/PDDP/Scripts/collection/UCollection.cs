using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    [CreateAssetMenu( menuName = MenuUtil.USER_COLLECTION)]
    public class UCollection : Scriptable {

        public List<User> users = new List<User> ();

    } // Class UCollection

} // Namespace PDDP