using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PDDP {

    [CreateAssetMenu(menuName = MenuUtil.ACHIEVEMENT_COLLECTION)]
    public class ACollection : Scriptable {

        public List<Achievement> achievements = new List<Achievement> ();

    } // Class ACollection

} // Namespace PDDP