﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using static Utility.Common;
using TES3Lib.Subrecords.REFR;
using Utility;
using System.Collections;

namespace TES3Lib.Base
{
    abstract public class Record
    {
        #region Fields

        /// <summary>
        /// Record name (4 bytes)
        /// </summary>
        readonly public string Name;

        /// <summary>
        /// Records data size (4 bytes)
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Not known (4 bytes)
        /// </summary>
        public int Header { get; set; }

        /// <summary>
        /// Record flags (4 bytes)
        ///  0x00002000 = Blocked
		///	 0x00000400 = Persistant
        /// </summary>
        public int Flags { get; set; }

        public DELE DELE { get; set; }

        /// <summary>
        /// Raw bytes of records data (variable)
        /// </summary>
        protected byte[] Data { get; set; }

        /// <summary>
        /// Just a switch to say from what source serialize
        /// </summary>
        protected bool IsImplemented = true;

        /// <summary>
        /// Raw bytes of record (record)
        /// </summary>
        private byte[] RawData { get; set; }

        #endregion

        public Record()
        {
            Flags = 0;
            Header = 0;
        }

        public Record(byte[] rawData)
        {
            RawData = rawData;
            var readerHeader = new ByteReader();
            Name = readerHeader.ReadBytes<string>(RawData, 4);
            Size = readerHeader.ReadBytes<int>(RawData);
            Header = readerHeader.ReadBytes<int>(RawData);
            Flags = readerHeader.ReadBytes<int>(RawData);
            Data = readerHeader.ReadBytes<byte[]>(RawData, (int)Size);
        }

        public virtual void BuildSubrecords()
        {
            if (!IsImplemented) return;

            var readerData = new ByteReader();
            while (Data.Length != readerData.offset)
            {
                string subrecordName = GetRecordName(readerData);
                int subrecordSize = GetRecordSize(readerData);
                try
                {
                    PropertyInfo subrecordProp = this.GetType().GetProperty(subrecordName);
                    if (subrecordProp.PropertyType.IsGenericType)
                    {
                        var listType = subrecordProp.PropertyType.GetGenericArguments()[0];
                        if (IsNull(subrecordProp.GetValue(this)))
                        {
                            var IListRef = typeof(List<>);
                            Type[] IListParam = { listType };
                            object subRecordList = Activator.CreateInstance(IListRef.MakeGenericType(IListParam));
                            subrecordProp.SetValue(this, subRecordList);
                        }
                        object sub = Activator.CreateInstance(listType, new object[] { readerData.ReadBytes<byte[]>(Data, subrecordSize) });

                        subrecordProp.GetValue(this).GetType().GetMethod("Add").Invoke(subrecordProp.GetValue(this), new[] { sub });
                        continue;
                    }
                    object subrecord = Activator.CreateInstance(subrecordProp.PropertyType, new object[] { readerData.ReadBytes<byte[]>(Data, subrecordSize) });
                    subrecordProp.SetValue(this, subrecord);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error in building {this.GetType().ToString()} on {subrecordName} eighter not implemented or borked {e}");
                    break;
                }
            }
        }

        public virtual byte[] SerializeRecord()
        {
            if (!IsImplemented) return RawData;
         
            var properties = this.GetType()
                .GetProperties(System.Reflection.BindingFlags.Public |
                               System.Reflection.BindingFlags.Instance |
                               System.Reflection.BindingFlags.DeclaredOnly)
                               .OrderBy(x => x.MetadataToken)
                               .ToList();
           
            if (properties.Any(x => x.Name.Equals("NAME")))
            {
                var index = properties.FindIndex(x => x.Name.Equals("NAME"));
                properties.Insert(++index, this.GetType().GetProperty("DELE"));
            }

            List<byte> data = new List<byte>();
            foreach (PropertyInfo property in properties)
            {             
                if (property.PropertyType.IsGenericType)
                {            
                    var subrecordList = property.GetValue(this) as IEnumerable;
                    if (subrecordList == null) continue;
                    foreach (var sub in subrecordList)
                    {
                        data.AddRange((sub as Subrecord).SerializeSubrecord());
                    }
                    continue;
                }
                var subrecord = (Subrecord)property.GetValue(this);
                if (subrecord == null) continue;
                data.AddRange(subrecord.SerializeSubrecord());
            }

            return Encoding.ASCII.GetBytes(this.GetType().Name)
                .Concat(BitConverter.GetBytes(data.Count()))
                .Concat(BitConverter.GetBytes(Header))
                .Concat(BitConverter.GetBytes(Flags))
                .Concat(data).ToArray();
        }

        protected string GetRecordName(ByteReader reader)
        {
            var name = reader.ReadBytes<string>(Data, 4);
            reader.ShiftBackBy(4);
            return name;
        }

        protected int GetRecordSize(ByteReader reader)
        {
            reader.ShiftForwardBy(4);
            var size = reader.ReadBytes<int>(Data) + 8;
            reader.ShiftBackBy(8);
            return size;
        }

        protected bool IsEndOfData(ByteReader reader) => (reader.offset == Data.Length);
    }
}
