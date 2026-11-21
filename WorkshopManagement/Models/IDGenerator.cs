using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopManagement.Models
{
    internal class IDGenerator
    {
        internal int nextID { get; private set; }
        private int end;
        private IDGenerator(int _start, int _end)
        {
            this.end = _end;
            this.nextID = _start;

        }

        internal static IDGenerator? CreateNewIDGenerator(int _start, int _end)
        {
            if(_start <= _end)
            {
                return new IDGenerator(_start, _end);
            }
            else
            {
                return null;
            }
        }
        internal int? GenerateID()
        {
            if (nextID <= this.end)
            {
                return nextID++;
            }
            else
            {
                return null;// OutOfRange
            }
        }
    }
}
