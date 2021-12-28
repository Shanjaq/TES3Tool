﻿using System.Diagnostics;
using TES3Lib.Base;
using TES3Lib.Subrecords.LIGH;
using TES3Lib.Subrecords.Shared;

namespace TES3Lib.Records
{
    /// <summary>
    /// Light object Record
    /// </summary>
    [DebuggerDisplay("{NAME.EditorId}")]
    public class LIGH : Record
    {
        /// <summary>
        /// Editor Id
        /// </summary>
        public NAME NAME { get; set; }

        /// <summary>
        /// Model
        /// </summary>
        public MODL MODL { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public FNAM FNAM { get; set; }

        /// <summary>
        /// Icon
        /// </summary>
        public ITEX ITEX { get; set; }

        /// <summary>
        /// Light parameters
        /// </summary>
        public LHDT LHDT { get; set; }

        /// <summary>
        /// Script
        /// </summary>
        public SCRI SCRI { get; set; }

        /// <summary>
        /// Sound EditorId
        /// </summary>
        public SNAM SNAM { get; set; }

        public LIGH()
        {
        }

        public LIGH(byte[] rawData) : base(rawData)
        {
            BuildSubrecords();
        }
    }
}
