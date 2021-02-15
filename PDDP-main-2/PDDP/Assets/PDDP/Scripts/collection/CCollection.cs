using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace PDDP {

    [CreateAssetMenu (menuName = MenuUtil.CHALLENGE_COLLECTION)]
    public class CCollection : Scriptable {

        public List<Challenge> challenges = new List<Challenge> ();

    } // Class CCollection

} // Namespace PDDP
