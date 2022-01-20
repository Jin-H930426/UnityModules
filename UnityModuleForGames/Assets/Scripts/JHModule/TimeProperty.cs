using UnityEngine;

namespace JHModule
{
    public class TimeProperty
    {
        /// time scale for play runtime
        public static float runtime_TimeScale {get { return Time.timeScale;} set {Time.timeScale = value;}}
        /// delta for play runtime
        public static float runtime_DeltaTime {get{return Time.deltaTime;}}
        /// time scale for ui runtime
        public static float ui_TimeScale {get;set;} = 1; 
        /// delta scale for runtime
        public static float ui_DeltaTime {get {return Time.unscaledDeltaTime;}}
    }
}