using System;
using System.Collections.Generic;
using System.Text;

namespace Hashing
{
    public class HashtableDto
    {
        public int Key { get; set; }
        public int Value { get; set; }

        public HashtableDto(int key, int value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
