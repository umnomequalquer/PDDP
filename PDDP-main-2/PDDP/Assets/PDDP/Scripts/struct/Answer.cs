using UnityEngine;
using System.Collections;

namespace PDDP {

    [System.Serializable]
    public struct Answer {
        public int uuid;
        public Sprite image;
        public Sprite icon;
        public string text;
        public bool isCorrect;
    } // Struct Answer

} // Namespace PDDP