using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopFacebook.CustomFeatures.FriendshipMatchScale.MatchCategoryTypes;

namespace DesktopFacebook.CustomFeatures.FriendshipMatchScale
{
    public class MatchCategoryContainer : IEnumerable
    {
        private readonly List<MatchCategory> m_MatchCategories;
        
        public MatchCategoryContainer(List<MatchCategory> i_ListMatchCategory)
        {
            m_MatchCategories = i_ListMatchCategory;
        }

        private class MatchCategoriesIterator : IEnumerator
        {
            private MatchCategoryContainer m_Container;
            private IEnumerator m_OriginalEnumerator;

            public MatchCategoriesIterator(MatchCategoryContainer i_Container)
            {
                m_Container = i_Container;
                m_OriginalEnumerator = m_Container.m_MatchCategories.GetEnumerator();
            }

            public object Current
            {
                get { return new PartialMatchCategory() { CategoryName = (m_OriginalEnumerator.Current as MatchCategory).CategoryName, MatchValue = (m_OriginalEnumerator.Current as MatchCategory).MatchValue }; }
            }

            public bool MoveNext()
            {
                return m_OriginalEnumerator.MoveNext();
            }

            public void Reset()
            {
                m_OriginalEnumerator.Reset();
            }
        }

        public IEnumerator GetEnumerator()
        { 
            return new MatchCategoriesIterator(this);
        }
    }
}
