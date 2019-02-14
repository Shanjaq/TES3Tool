﻿using TES4Lib.Structures.Base;
using Utility;

namespace TES4Lib.Subrecords.LIGH
{
    public class ICON : Subrecord
    {
        public string IconFileName { get; set; }

        public ICON(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            IconFileName = reader.ReadBytes<string>(base.Data, base.Size);
        }
    }
}