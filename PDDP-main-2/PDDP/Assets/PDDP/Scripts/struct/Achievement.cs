using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    [System.Serializable]
    public struct Achievement {
        public int uuid;
        public Sprite icon;
        public string name;
        public string desc;
        public Status status;
        public int progress;
    } // Struct Achievement

} // Namespace PDDP