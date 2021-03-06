﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pen
{
    class PensRepository : BasePenRepository, IPenRepository, IPens
    {
        private Pen[] _pens;

        public int Count { get; private set; }

        public PensRepository(int size)
        {
            _pens = new Pen[size];
        }

        public Pen this[int index]
        {
            get
            {
                if (index >= 0 && index < _pens.Length)
                {
                    return _pens[index];
                }
                else
                {
                    return null;
                }
            }
        }

        public override void Add(Pen pen)
        {
            if (pen == null || Count == _pens.Length)
            {
                Console.WriteLine("Invalid input parameter or repository is full");
                return;
            }
            _pens[Count++] = pen;
        }
        // Explicit interface implementation
        void IPenRepository.Delete(int index)
        {
            if (index >= 0 && index < Count)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (i < index)
                    {
                        _pens[i] = _pens[i];
                    }
                    else
                    {
                        _pens[i] = _pens[i + 1];
                    }
                }
                Count--;
            }
            else
            {
                Console.WriteLine("Index out of range!");
            }           
        }
        // Explicit interface implementation
        void IPens.Delete(int index)
        {

        }

        public override Pen Get(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            for (int i = 0; i < Count; i++)
            {
                if (_pens[i].Id == id)
                {
                    return _pens[i];
                }
            }
            return null;
        }
    }
}
