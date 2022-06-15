﻿using TES3Lib.Base;
using Utility;

namespace TES3Lib.Subrecords.NPC_
{
    /// <summary>
    /// Race name
    /// </summary>
    public class RNAM : Subrecord
    {
        public string RaceName { get; set; }

        public RNAM()
        {
        }

        public RNAM(byte[] rawData) : base(rawData)
        {
            var reader = new ByteReader();
            RaceName = reader.ReadBytes<string>(Data, Size);
        }
    }
}
