using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace PDDP {

    [ExecuteInEditMode]
    public class ProgressBar : MonoBehaviour {

        [SerializeField] private int minimun;
        public int maximun;
        public int current;

        [Space (10)]

        public Image fill;
        public Image reverseFill;

        private void Update () {
            SetBarFillAmount ();
        } // Update

        public void SetBarFillAmount () {
            float currentOffset = current - minimun;
            float maximunOffset = maximun - minimun;

            float fillAmount = currentOffset / maximunOffset;
            fill.fillAmount = fillAmount;

            if (reverseFill != null) {
                float reverseFillAmount = (maximunOffset / maximun) - fillAmount;
                reverseFill.fillAmount = reverseFillAmount;
            }
        } // SetBarFillAmount

    } // Class ProgressBar

} // Namespace PDDP