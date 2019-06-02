using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbeFly.BoardControl
{
    public class BoardList: IList<Board>
    {

        public int Count => _itemList.Count;

        public bool IsReadOnly => false;

        private readonly List<Board> _itemList = new List<Board>();

        public int IndexOf(Board item)
        {
            return _itemList.IndexOf(item);
        }

        public void Insert(int index, Board item)
        {
            _itemList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            _itemList.RemoveAt(index);
        }

        public Board this[int index]
        {
            set
            {
                if (CheckListRange(index))
                {
                    _itemList[index] = value;
                }
            }
            get
            {
                if (CheckListRange(index))
                {
                    return _itemList[index];
                }

                return null;
            }
        }

        private bool CheckListRange(int index)
        {
            if ((index < 0) || (index >= _itemList.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index));                
            }

            return true;
        }


        public IEnumerator<Board> GetEnumerator()
        {
            return _itemList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(Board item)
        {
            _itemList.Add(item);
        }

        public void Clear()
        {
            _itemList.Clear();
        }

        public bool Contains(Board item)
        {
            return _itemList.Contains(item);
        }

        public void CopyTo(Board[] array, int arrayIndex)
        {
            _itemList.CopyTo(array, arrayIndex);
        }

        public bool Remove(Board item)
        {
            return _itemList.Remove(item);
        }

        /// <summary>
        /// Return first available spot in Ini file that can be used for new board
        /// For example, if 0,1,3 are taken it will return 2
        /// If 0,1,2,3 taken it will return 4
        /// If no spot is available it will return -1
        /// </summary>
        /// <returns></returns>
        public int GetFirstAvailableBoardIniPosition()
        {

            if (_itemList.Count == 0)
            {
                return 0; // no bard was loaded before
            }

            for (int loop = 0; loop < _itemList.Count; loop++)
            {
                if (_itemList[loop].IsAvailableToReuse)
                {
                    return loop;
                }
            }

            if (_itemList.Count == Defs.MAX_BOARDS - 1) // all spots are taken
            {
                return -1;
            }

            return _itemList.Count;

        }

    }
}
