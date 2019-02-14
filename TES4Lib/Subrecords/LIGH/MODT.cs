﻿using TES4Lib.Structures.Base;
using Utility;

namespace TES4Lib.Subrecords.LIGH
{
    public class MODT : Subrecord
    {
        public string ModelFileName { get; set; }

        public MODT(byte[] rawData) : base(rawData)
        {
        }
    }
}