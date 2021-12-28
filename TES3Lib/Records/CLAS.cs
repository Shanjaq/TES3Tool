﻿using System.Diagnostics;
using TES3Lib.Base;
using TES3Lib.Subrecords.CLAS;
using TES3Lib.Subrecords.Shared;

namespace TES3Lib.Records
{
    [DebuggerDisplay("{NAME.EditorId}")]
    public class CLAS : Record
    {
        /// <summary>
        /// EditorId
        /// </summary>
        public NAME NAME { get; set; }

        /// <summary>
        /// Display name
        /// </summary>
        public FNAM FNAM { get; set; }

        /// <summary>
        /// Attributes and skills
        /// </summary>
        public CLDT CLDT { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public DESC DESC { get; set; }

        public CLAS()
        {
        }

        public CLAS(byte[] rawData) : base(rawData)
        {
            BuildSubrecords();
        }
    }
}
