﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDesignPattern.BehavioralDesignPattern._3_Interator
{
    public class _1_Interator
    {
        void Invoke_Interator()
        {
            // 声明一个聚合类
            IListCollection list = new ConcreteList();
            // 声明一个迭代器
            Iterator iterator = list.GetIterator();
            // 使用迭代器遍历
            while (iterator.MoveNext())
            {
                int i = (int)iterator.GetCurrent();
                Console.WriteLine(i.ToString());
                iterator.Next();
            }

            Console.Read();
        }

        #region 抽象类

        // 抽象聚合类
        public interface IListCollection
        {
            Iterator GetIterator();
        }

        // 迭代器抽象类
        public interface Iterator
        {
            bool MoveNext();

            Object GetCurrent();

            void Next();

            void Reset();
        }

        #endregion 抽象类

        #region 具体类

        // 具体聚合类
        public class ConcreteList : IListCollection
        {
            private int[] collection;

            public ConcreteList()
            {
                collection = new int[] { 2, 4, 6, 8 };
            }

            public Iterator GetIterator()
            {
                return new ConcreteIterator(this);
            }

            public int Length
            {
                get { return collection.Length; }
            }

            public int GetElement(int index)
            {
                return collection[index];
            }
        }

        // 具体迭代器类
        public class ConcreteIterator : Iterator
        {
            // 迭代器要集合对象进行遍历操作，自然就需要引用集合对象
            private ConcreteList _list;

            private int _index;

            public ConcreteIterator(ConcreteList list)
            {
                _list = list;
                _index = 0;
            }

            public bool MoveNext()
            {
                if (_index < _list.Length)
                {
                    return true;
                }
                return false;
            }

            public Object GetCurrent()
            {
                return _list.GetElement(_index);
            }

            public void Reset()
            {
                _index = 0;
            }

            public void Next()
            {
                if (_index < _list.Length)
                {
                    _index++;
                }
            }
        }

        #endregion 具体类
    }
}