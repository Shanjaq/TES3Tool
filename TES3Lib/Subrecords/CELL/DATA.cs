﻿using System.Collections.Generic;
using TES3Lib.Base;
using TES3Lib.Enums.Flags;
using Utility;

namespace TES3Lib.Subrecords.CELL
{
    public class DATA : Subrecord
    {
        public HashSet<CellFlag> Flags { get; set; }

        public int GridX { get; set; }

        public int GridY { get; set; }

        public DATA()
        {
        }

        public DATA(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            Flags = reader.ReadFlagBytes<CellFlag>(Data);
            GridX = reader.ReadBytes<int>(Data);
            GridY = reader.ReadBytes<int>(Data);
        }
    }
}

