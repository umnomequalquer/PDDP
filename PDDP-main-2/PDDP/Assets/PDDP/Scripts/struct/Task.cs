using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PDDP {

    [System.Serializable]
    public struct Task {
        public int uuid;
        public Sprite icon;
        public string name;
        public string desc;
        public Status status;
        public float progress;
    } // Struct Task

} // Namespace PDDP
