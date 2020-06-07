using PathCreation;
using UnityEngine;

namespace PathCreation.Examples {

    [ExecuteInEditMode]
    public class PathPlacer : PathSceneTool {

        [SerializeField]
        private int randommax;

        public GameObject[] prefab;

        [SerializeField]
        private float initialstartspawn = 65;

        
        //make it as array and get random prefab 
        public GameObject holder;
        public float spacing = 3;

        const float minSpacing = .1f;

        private void Start()
        {
            randommax = prefab.Length;
            Debug.Log(randommax);
        }





        void Generate () 
        {
            if (pathCreator != null && holder != null)//(pathCreator != null && prefab != null && holder != null)
            {
                DestroyObjects ();

                VertexPath path = pathCreator.path;

                spacing = Mathf.Max(minSpacing, spacing);
                float dst = 0;

                while (dst < path.length) 
                {
                    if(dst==0||dst<initialstartspawn)
                    {
                        dst += spacing;
                        //in starting add diamond collection for more interactive
                    }
                    else
                    {
                        if(dst<path.length-75)
                        {
                            Vector3 point = path.GetPointAtDistance(dst);
                            Quaternion rot = path.GetRotationAtDistance(dst);
                            Instantiate(prefab[Random.Range(0, randommax)], point, rot, holder.transform);
                        }
                        
                        dst += spacing;
                      //  Debug.Log(path.GetPointAtDistance(dst));
                      
                    }
                   /* Vector3 point = path.GetPointAtDistance (dst);
                    Quaternion rot = path.GetRotationAtDistance (dst);
                    Instantiate (prefab[Random.Range(0,7)], point, rot, holder.transform);
                    dst += spacing;*/
                }
            }
        }

        void DestroyObjects () {
            int numChildren = holder.transform.childCount;
            for (int i = numChildren - 1; i >= 0; i--) {
                DestroyImmediate (holder.transform.GetChild (i).gameObject, false);
            }
        }

        protected override void PathUpdated () {
            if (pathCreator != null) {
                Generate ();
            }
        }
    }
}