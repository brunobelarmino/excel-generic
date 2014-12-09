using Excel.Generic.Utils;
using NUnit.Framework;
using System;

namespace Excel.Generic.Test
{
    [TestFixture]
    public class CastTest
    {
        [Test]
        public void CastFloat()
        { 
            string val = "10.1";
            Type type = typeof(float);

            var result = (float)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastDouble()
        {
            var val = "1000.99";
            Type type = typeof(double);

            var result = (double)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastByte()
        {
            var val = "255";
            Type type = typeof(byte);

            var result = (byte)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastSByte()
        {
            var val = "-120";
            Type type = typeof(sbyte);

            var result = (sbyte)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastInt()
        {
            var val = "2147483647";
            Type type = typeof(int);

            var result = (int)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastUInt()
        {
            var val = "4294967295";
            Type type = typeof(uint);

            var result = (uint)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastShort()
        {
            var val = "-32768";
            Type type = typeof(short);

            var result = (short)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastUShort()
        {
            var val = "65535";
            Type type = typeof(ushort);

            var result = (ushort)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastLong()
        {
            var val = "223372036854775807";
            Type type = typeof(long);

            var result = (long)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastULong()
        {
            var val = "18446744073709551615";
            Type type = typeof(ulong);

            var result = (ulong)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastChar()
        {
            var val = "*";
            Type type = typeof(char);

            var result = (char)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastBool()
        {
            var val = "false";
            Type type = typeof(bool);

            var result = (bool)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastObject()
        {
            var val = "object";
            Type type = typeof(object);

            var result = Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastString()
        {
            var val = "string";
            Type type = typeof(string);

            var result = Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastDecimal()
        {
            var val = "7922816251426433759354395.0335";
            Type type = typeof(decimal);

            var result = (decimal)Cast.ToType(val, type);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastDateTimeNumber()
        {
            var val = "41974";
            Type type = typeof(DateTime);

            var result = Cast.ToDate(val);

            Assert.IsInstanceOf(type, result);
        }

        [Test]
        public void CastDateTime()
        {
            var val = "12/10/2014";
            Type type = typeof(DateTime);

            var result = Cast.ToDate(val);

            Assert.IsInstanceOf(type, result);
        }
    }
}
