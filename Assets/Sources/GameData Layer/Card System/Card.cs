using UnityEngine;

namespace CardSystem
{
    public interface ICard
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}