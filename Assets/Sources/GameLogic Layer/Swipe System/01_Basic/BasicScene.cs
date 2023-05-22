using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SwipeableView
{
    public class BasicScene : MonoBehaviour
    {
        public static BasicScene instance;
        [SerializeField]
        private UISwipeableViewBasic swipeableView = default;

        public static UISwipeableViewBasic SwipeableView => instance.swipeableView;

        void Start()
        {
            var data = Enumerable.Range(0, 20)
                .Select(i => new BasicCardData
                {
                    color = new Color(Random.value, Random.value, Random.value, 1.0f)
                })
                .ToList();

            swipeableView.UpdateData(data);
        }
        private void Awake()
        {
            if(instance == null)
            {
                instance = this;
            }
        }
    }
}