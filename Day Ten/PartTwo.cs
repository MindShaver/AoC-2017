using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DayTen
{
    public class PartTwo
    {
        public string Solve()
        {
            var extra = new List<byte> { 17, 31, 73, 47, 23 };
            const string lengthSequence = "14,58,0,116,179,16,1,104,2,254,167,86,255,55,122,244";
            var asciiLengthSequence = Encoding.ASCII.GetBytes(lengthSequence).ToList();
            asciiLengthSequence.AddRange(extra);

            var sparseHash = new int[256];
            var skip = 0;
            var counter = 0;

            for (var i = 0; i < sparseHash.Length; i++)
            {
                sparseHash[i] = i;
            }

            for (var round = 1; round <= 64; round++)
            {
                foreach (var instruction in asciiLengthSequence)
                {
                    var arraySubset = new int[instruction];
                    var localCount = counter;
                    for (var i = 0; i < instruction; i++)
                    {
                        if (localCount >= sparseHash.Length)
                        {
                            localCount = 0;
                        }

                        arraySubset[i] = sparseHash[localCount];
                        localCount++;
                    }

                    var reverse = arraySubset.Reverse().ToArray();
                    localCount = counter;

                    for (var i = 0; i < instruction; i++)
                    {
                        if (localCount >= sparseHash.Length)
                        {
                            localCount = 0;
                        }

                        sparseHash[localCount] = reverse[i];

                        localCount++;
                    }

                    counter += instruction + skip;

                    counter = counter % sparseHash.Length;

                    skip++;
                }
            }

            var denseHash = new List<byte>();

            for (var i = 0; i < 255; i += 16)
            {
                denseHash.Add((byte) (sparseHash[i] ^ sparseHash[i + 1] ^ sparseHash[i + 2] ^ sparseHash[i + 3] ^ sparseHash[i + 4] ^ sparseHash[i + 5] 
                    ^ sparseHash[i + 6] ^ sparseHash[i + 7] ^ sparseHash[i + 8] ^ sparseHash[i + 9] ^ sparseHash[i + 10] ^ sparseHash[i + 11] 
                    ^ sparseHash[i + 12] ^ sparseHash[i + 13] ^ sparseHash[i + 14] ^ sparseHash[i + 15]));
            }

            var knotHash = new StringBuilder(denseHash.Count * 2);
            foreach (var value in denseHash)
                knotHash.AppendFormat("{0:x2}", value);

            return knotHash.ToString();
        }
    }
}
