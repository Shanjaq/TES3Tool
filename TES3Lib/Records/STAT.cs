﻿using TES3Lib.Structures.Base;
using TES3Lib.Subrecords.STAT;

namespace TES3Lib.Records
{
    public class STAT : Record
    {
        public NAME NAME { get; set; }
        public MODL MODL { get; set; }

        public STAT()
        {
            Flags = 0;
            Header = 0;
        }

        public STAT(byte[] rawData) : base(rawData)
        {
            BuildSubrecords();
        }
    }
}
