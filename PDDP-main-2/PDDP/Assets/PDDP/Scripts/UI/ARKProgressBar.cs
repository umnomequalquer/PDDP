using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

namespace PDDP {

    [ExecuteInEditMode ()]
    public class ARKProgressBar : MonoBehaviour {

        #region Variables 
        public ProgressBarType type;
        public DisplayType displayType;

        [Space (10)]

        [SerializeField] private int minimun;
        [SerializeField] private int maximun;
        [SerializeField] private int current;

        [Space(10)]

        public Image bar;
        public Image mask;
        public Image fill;

        [Space (10)]

        [ConditionalHide (nameof (type) , 1)]
        public ProgressBarDirection direction;
        [ConditionalHide (nameof (type) , 0)]
        public bool clockwise;

        [Space (10)]

        [ConditionalHide (nameof (displayType) , 1)]
        public Color fillColor;
        [ConditionalHide (nameof (displayType) , 1)]
        public Color backgroundColor;

        [ConditionalHide (nameof (displayType) , 0)]
        public Sprite fillSprite;
        [ConditionalHide (nameof (displayType) , 0)]
        public Sprite backgroundSprite;
        #endregion

        void Awake () {
            Init ();
        } // Awake;

        #region Init

        private void Init () {
            AssignComponents ();
            DrawBar ();
            FillOrigin ();
        } // Init;

        private void AssignComponents () {
            bar = GetComponent<Image> ();
            //mask = transform.Find ("Mask").GetComponent<Image> ();
            fill = this.transform.Find ("Fill").GetComponent<Image> ();
        } // AssignComponents;

        private void FillOrigin () {
            switch (type) {
                case ProgressBarType.Linear:
                    switch (direction) {
                        case ProgressBarDirection.Left:
                            mask.fillOrigin = 0;
                            fill.fillOrigin = 0;
                            break;
                        case ProgressBarDirection.Right:
                            mask.fillOrigin = 1;
                            fill.fillOrigin = 1;
                            break;
                    }
                    break;
                case ProgressBarType.Radial:
                    if (clockwise) {
                        mask.fillClockwise = true;
                        fill.fillClockwise = true;
                    } else {
                        mask.fillClockwise = false;
                        fill.fillClockwise = false;
                    }
                    break;
            }

        } // FillOrigin;

        #endregion

        private void Update () {
            SetBarFillAmount ();

            #if UNITY_EDITOR
            DrawBar ();
            #endif
        } // Update;

        public void SetBarFillAmount () {
            float currentOffset = current - minimun;
            float maximunOffset = maximun - minimun;

            float fillAmount = currentOffset / maximunOffset;
            fill.fillAmount = fillAmount;
        } // SetBarFillAmount;
        
        #region Bar Design

        private void DrawBar () {
            switch (displayType) {
                case DisplayType.Color:
                    DrawColor ();
                    break;
                case DisplayType.Sprite:
                    DrawSprite ();
                    break;
                case DisplayType.Both:
                    DrawColor ();
                    DrawSprite ();
                    break;
            }
        } // DrawBar;

        private void DrawColor () {
            if (fill != null)
                fill.color = fillColor;

            if (mask != null)
                mask.color = fillColor;

            if (bar != null)
                bar.color = backgroundColor;
        } // DrawColor;

        private void DrawSprite () {
            if (backgroundSprite != null)
                bar.sprite = backgroundSprite;

            if (fillSprite != null)
                return;

            if (fill != null)
                fill.sprite = fillSprite;

            if (mask != null)
                mask.sprite = fillSprite;
        } // DrawSprite;

        #endregion

        #region Getters & Setters

        public void SetMinimunFill (int amount) {
            if (amount < 0)
                return;

            minimun = amount;
        } // SetMinimunFill;

        public int GetMinimunFill () {
            return minimun;
        } // GetMinimunFill;


        public void AddFillAmount (int amount) {
            if ((current + amount) > maximun)
                current = maximun;
            else
                current += amount;

            if (current < minimun)
                current = minimun;
        } // AddFillAmount;

        public void SetCurrentFill (int amount) {
            if (amount < minimun || amount > maximun)
                return;

            current = amount;
        } // SetCurrentFill;

        public int GetCurrentFill() {
            return current;
        } // GetCurrentFill;


        public void SetMaximunFill (int amount) {
            if (amount < 0)
                return;

            maximun = amount;
        } // SetMinimunFill;

        public int GetMaximunFill () {
            return maximun;
        } // GetMaximunFill;

        #endregion

        #region Editor 

        #if UNITY_EDITOR
       
        [MenuItem (MenuUtil.LINEAR_ITEM)]
        public static void AddLinearProgressBar () {
            GameObject obj = Instantiate (Resources.Load<GameObject> ("Prefab/Linear Progress Bar"));
            obj.name = "Linear Bar";
            obj.transform.SetParent (Selection.activeGameObject.transform , false);
        } // AddLinearProgressBar;

        [MenuItem (MenuUtil.RADIAL_ITEM)]
        public static void AddRadialProgressBar () {
            GameObject obj = Instantiate (Resources.Load<GameObject> ("Prefab/Radial Progress Bar"));
            obj.name = "Radial Bar";
            obj.transform.SetParent (Selection.activeGameObject.transform , false);
        } // AddRadialProgressBar;

        #endif

        #endregion

    } // Class ARKProgressBar;

    public enum DisplayType { Color, Sprite, Both } // Enum DisplayType;

    public enum ProgressBarDirection { Left, Right } // Enum ProgressBarDirection;

    public enum ProgressBarType { Linear, Radial } // Enum ProgressBarType;

} // Namespace PDDP